using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using TheFisher.DAL.enums;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;

namespace TheFisher.BLL.Services;

public class PurchaseService(FisherDbContext context) : IPurchaseService
{
    public async Task<Purchase> CreatePurchaseAsync(PurchaseCreateDto purchaseCreateDto)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var item = await context.Items.FindAsync(purchaseCreateDto.ItemId);
            if (item == null)
            {
                throw new Exception("Item not found");
            }

            var dealer = await context.Dealers.FindAsync(purchaseCreateDto.DealerId);
            if (dealer == null)
            {
                throw new Exception("Dealer not found");
            }
            
            var actualKiloPrice = purchaseCreateDto.KiloPrice;

            if (purchaseCreateDto.Tax.HasValue)
            {
                actualKiloPrice = purchaseCreateDto.KiloPrice!.Value +
                                  (purchaseCreateDto.Tax!.Value / purchaseCreateDto.TotalWeight);
            }

            var purchase = new Purchase
            {
                DealerId = purchaseCreateDto.DealerId,
                ItemId = purchaseCreateDto.ItemId,
                TotalUnits = purchaseCreateDto.TotalUnits,
                UnitPrice = actualKiloPrice,
                TotalWeight = purchaseCreateDto.TotalWeight,
                WeightAvailable = purchaseCreateDto.TotalWeight,
                Type = purchaseCreateDto.Type,
                Date = purchaseCreateDto.Date,
                Tax = purchaseCreateDto.Tax,
                TransportationFees = purchaseCreateDto.TransportationFees
            };

            await context.Purchases.AddAsync(purchase);
            
            dealer.OutstandingBalance -= purchaseCreateDto.TransportationFees;

            if (purchaseCreateDto.Type == PurchaseType.Direct)
            {
                // Update average price (weighted average)
                var totalValue = (item.Stock * item.AvgPricePerKg) +
                                 (purchaseCreateDto.TotalWeight * purchaseCreateDto.KiloPrice!.Value);
                var totalWeight = item.Stock + purchaseCreateDto.TotalWeight;

                if (totalWeight > 0)
                {
                    item.AvgPricePerKg = totalValue / totalWeight;
                }

                item.Stock += purchaseCreateDto.TotalWeight;
            }
            else
            {
                item.CommissionedStock += purchaseCreateDto.TotalWeight;
            }


            context.Items.Update(item);
            context.Dealers.Update(dealer);

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            return purchase;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<Purchase>> GetTodaysPurchasesAsync()
    {
        var today = DateTime.Today;
        return await context.Purchases
            .Include(p => p.Dealer)
            .Include(p => p.Item)
            .Where(p => p.Date.Date == today)
            .OrderByDescending(p => p.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Purchase>> GetPurchasesByDealerAsync(int dealerId)
    {
        return await context.Purchases
            .Include(p => p.Dealer)
            .Include(p => p.Item)
            .Where(p => p.DealerId == dealerId)
            .OrderByDescending(p => p.Date)
            .ToListAsync();
    }

    public async Task<decimal> GetMoneyOwedToDealersAsync()
    {
        var purchases = await context.Purchases
            .Where(p => p.Type == PurchaseType.Direct && p.UnitPrice.HasValue)
            .ToListAsync();

        return purchases.Sum(p => p.TotalWeight * p.UnitPrice!.Value);
    }
}