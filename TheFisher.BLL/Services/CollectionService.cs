using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;
using TheFisher.DAL.enums;

namespace TheFisher.BLL.Services;

public class CollectionService(FisherDbContext context, IOrderService orderService) : ICollectionService
{
    public async Task CreateCollectionAsync(CreateCollectionDto createCollectionDto)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var unpaidOrders = await context.Orders
                .Include(o => o.OrderPurchases)
                .ThenInclude(op => op.Purchase)
                .Where(o => o.ClientId == createCollectionDto.ClientId && o.Total > o.Collected)
                .OrderBy(o => o.Date)
                .ToListAsync();

            var profit = 0m;
            var collectedAmount = createCollectionDto.Amount;
            var collectionDetails = new List<CollectionDetail>();
            
            foreach (var unpaidOrder in unpaidOrders)
            {
                var toPay = Math.Min(unpaidOrder.Remaining, collectedAmount);
                var orderProfit = 0m;
                
                if(toPay == 0)
                    break;
                
                collectedAmount -= toPay;
                
                foreach (var orderPurchase in unpaidOrder.OrderPurchases.OrderBy(op => op.Purchase.Date))
                {
                    var remainingAmount = orderPurchase.OrderShare - orderPurchase.SettledAmount;

                    if (remainingAmount > 0)
                    {
                        var payPerPurchase = Math.Min(toPay, remainingAmount);
                        orderPurchase.SettledAmount += payPerPurchase;

                        toPay -= payPerPurchase;
                        
                        // calculate profit
                        var purchase = orderPurchase.Purchase;
                        if (purchase.Type == PurchaseType.Direct)
                        {
                            var taxSharePerBoughtUnit = purchase.Tax!.Value / purchase.TotalWeight;
                            var cost = purchase.UnitPrice!.Value * orderPurchase.WeightUsed +
                                       orderPurchase.WeightUsed * taxSharePerBoughtUnit;

                            var taxSharePerSoldUnit = unpaidOrder.Tax / unpaidOrder.Weight;
                            var sellingPrice = unpaidOrder.KiloPrice * orderPurchase.WeightUsed + taxSharePerSoldUnit * orderPurchase.WeightUsed;

                            profit += sellingPrice - cost;
                        }
                        else
                        {
                            var taxSharePerSoldUnit = unpaidOrder.Tax / unpaidOrder.Weight;
                            var sellingPrice = unpaidOrder.KiloPrice * orderPurchase.WeightUsed + taxSharePerSoldUnit * orderPurchase.WeightUsed;

                            orderProfit += sellingPrice * (100 - purchase.CommissionPercent!.Value) / 100;
                        }
                    }
                }

                profit += orderProfit;

                var collectionDetail = new CollectionDetail()
                {
                    Id = Ulid.NewUlid(),
                    Amount = toPay,
                    Profit = orderProfit,
                    OrderId = unpaidOrder.Id
                };
                collectionDetails.Add(collectionDetail);

                unpaidOrder.Collected += toPay;
            }

            var collection = new Collection
            {
                Id = Ulid.NewUlid(),
                ClientId = createCollectionDto.ClientId,
                Amount = createCollectionDto.Amount,
                Date = createCollectionDto.Date,
                Profit = profit,
                CollectionDetails = collectionDetails
            };

            await context.Collections.AddAsync(collection);

            // Update client balance
            var client = await context.Clients.FindAsync(createCollectionDto.ClientId);
            if (client != null)
            {
                client.OutstandingBalance -= createCollectionDto.Amount;
                context.Clients.Update(client);
            }

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<GetCollectionDto>> GetTodaysCollectionsAsync()
    {
        var today = DateTime.Today;
        return await context.Collections
            .Include(c => c.Client)
            .Where(c => c.Date.Date == today)
            .OrderByDescending(c => c.Date)
            .Select(c => new GetCollectionDto(c.Id, c.Client.Name, c.Amount, c.Date))
            .ToListAsync();
    }

    public async Task<IEnumerable<GetCollectionDto>> GetCollectionsByClientAsync(int clientId)
    {
        return await context.Collections
            .Include(c => c.Client)
            .Where(c => c.ClientId == clientId)
            .OrderByDescending(c => c.Date)
            .Select(c => new GetCollectionDto(c.Id, c.Client.Name, c.Amount, c.Date))
            .ToListAsync();
    }

    public async Task<decimal> GetCurrentMonthCollectionsAsync()
    {
        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        var collections = await context.Collections
            .Where(c => c.Date >= startOfMonth && c.Date <= endOfMonth)
            .ToListAsync();

        return collections.Sum(c => c.Amount);
    }
}