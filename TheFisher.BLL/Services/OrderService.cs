using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using TheFisher.DAL.enums;

using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;

namespace TheFisher.BLL.Services;

public class OrderService(FisherDbContext context) : IOrderService
{
    public async Task CreateOrderAsync(OrderCreateDto orderDto)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            // Validate item availability
            var availablePurchases =  await context.Purchases
                .Include(p => p.Dealer)
                .Include(p => p.Item)
                .Where(p => p.ItemId == orderDto.ItemId && p.WeightAvailable > 0)
                .OrderBy(p => p.Date) // FIFO
                .ToListAsync();
          
            var totalAvailable = availablePurchases.Sum(p => p.WeightAvailable);

            if (totalAvailable < orderDto.Weight)
            {
                throw new InvalidOperationException($"Insufficient stock. Available: {totalAvailable}kg, Requested: {orderDto.Weight}kg");
            }

            // Create order
            var order = new Order
            {
                ClientId = orderDto.ClientId,
                ItemId = orderDto.ItemId,
                Weight = orderDto.Weight,
                KiloPrice = orderDto.KiloPrice,
                Date = orderDto.Date,
                Collected = 0,
                Tax = orderDto.Tax,
            };

            await context.Orders.AddAsync(order);

            // Link order to purchases (FIFO)
            decimal remainingWeight = orderDto.Weight;
            decimal normalStock = 0, commissionedStock = 0;
            
            foreach (var purchase in availablePurchases.OrderBy(p => p.Date))
            {
                if (remainingWeight <= 0) break;

                decimal weightToUse = Math.Min(remainingWeight, purchase.WeightAvailable);
                    
                // Create order-purchase link
                var orderPurchase = new OrderPurchase
                {
                    OrderId = order.Id,
                    PurchaseId = purchase.Id,
                    WeightUsed = weightToUse
                };
                    
                context.OrderPurchases.Add(orderPurchase);

                // Update purchase available weight
                purchase.WeightAvailable -= weightToUse;
                
                if (purchase.Type == PurchaseType.Direct)
                {
                    normalStock += weightToUse;
                }
                else
                {
                    commissionedStock += weightToUse;
                    purchase.Dealer.OutstandingBalance += order.KiloPrice * weightToUse * (100 - purchase.CommissionPercent!.Value) / 100;
                }
               
                context.Purchases.Update(purchase);

                remainingWeight -= weightToUse;
            }
            
            // Update client balance
            var client = await context.Clients.FindAsync(orderDto.ClientId);
            if (client == null) throw new Exception("Client not found");
            
            client.OutstandingBalance += order.Total;
            context.Clients.Update(client);

            // Update item stock
            var item = await context.Items.FindAsync(orderDto.ItemId);
            if (item != null)
            {
                item.Stock -= normalStock;
                item.CommissionedStock -= commissionedStock;
                context.Items.Update(item);
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
    

    public async Task<IEnumerable<GetOrderDto>> GetTodaysOrdersAsync()
    {
        var today = DateTime.Today;
        return await context.Orders
            .Where(o => o.Date.Date == today)
            .OrderByDescending(o => o.Date)
            .Select(o => new GetOrderDto(o.Id, o.Client.Name, o.Item.Name, o.Weight, o.KiloPrice, o.Date, o.Tax))
            .ToListAsync();    }

    public async Task<IEnumerable<GetOrderDto>> GetOrdersByClientAsync(int clientId)
    {
        return await context.Orders
            .Include(o => o.Client)
            .Include(o => o.Item)
            .Where(o => o.ClientId == clientId)
            .OrderByDescending(o => o.Date)
            .Select(o => new GetOrderDto(o.Id, o.Client.Name, o.Item.Name, o.Weight, o.KiloPrice, o.Date, o.Tax))
            .ToListAsync();
    }

    public async Task<decimal> GetCurrentMonthRevenueAsync()
    {
        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        var orders = await context.Orders
            .Where(o => o.Date >= startOfMonth && o.Date <= endOfMonth)
            .ToListAsync();

        return orders.Sum(o => o.Total);
    }

    public async Task<decimal> GetMoneyClientsOweAsync()
    {
        var clients = await context.Clients.ToListAsync();
        return clients.Sum(c => c.OutstandingBalance);
    }

    public async Task<IEnumerable<GetOrderDto>> GetClientUnpaidOrdersAsync(int clientId)
    {
        return await context.Orders
            .Where(o => o.ClientId == clientId && (o.KiloPrice * o.Weight) > o.Collected)
            .Select(o => new GetOrderDto(o.Id, o.Client.Name, o.Item.Name, o.Weight, o.KiloPrice, o.Date, o.Tax))
            .ToListAsync();
    }
}