using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using TheFisher.DAL.enums;

using Microsoft.EntityFrameworkCore;

namespace TheFisher.BLL.Services;

public class PurchaseService : IPurchaseService
{
    private readonly FisherDbContext _context;

    public PurchaseService(FisherDbContext context)
    {
        _context = context;
    }

    public async Task<Purchase> CreatePurchaseAsync(PurchaseCreateDto purchaseCreateDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var purchase = new Purchase
            {
                DealerId = purchaseCreateDto.DealerId,
                ItemId = purchaseCreateDto.ItemId,
                TotalUnits = purchaseCreateDto.TotalUnits,
                UnitPrice = purchaseCreateDto.KiloPrice,
                TotalWeight = purchaseCreateDto.TotalWeight,
                WeightAvailable = purchaseCreateDto.TotalWeight,
                Type = purchaseCreateDto.Type,
                Date = purchaseCreateDto.Date,
                Tax = purchaseCreateDto.Tax,
                TransportationFees = purchaseCreateDto.TransportationFees
            };

            await _context.Purchases.AddAsync(purchase);

            // Update item stock and average price
            var item = await _context.Items.FindAsync(purchaseCreateDto.ItemId);
            if (item == null)
            {
                throw new Exception("Item not found");
            }

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

            _context.Items.Update(item);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return purchase;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<Purchase>> GetAllPurchasesAsync()
    {
        return await _context.Purchases
            .Include(p => p.Dealer)
            .Include(p => p.Item)
            .OrderByDescending(p => p.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Purchase>> GetTodaysPurchasesAsync()
    {
        var today = DateTime.Today;
        return await _context.Purchases
            .Include(p => p.Dealer)
            .Include(p => p.Item)
            .Where(p => p.Date.Date == today)
            .OrderByDescending(p => p.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Purchase>> GetPurchasesByDealerAsync(int dealerId)
    {
        return await _context.Purchases
            .Include(p => p.Dealer)
            .Include(p => p.Item)
            .Where(p => p.DealerId == dealerId)
            .OrderByDescending(p => p.Date)
            .ToListAsync();
    }

    public async Task<decimal> GetMoneyOwedToDealersAsync()
    {
        var purchases = await _context.Purchases
            .Where(p => p.Type == PurchaseType.Direct && p.UnitPrice.HasValue)
            .ToListAsync();

        return purchases.Sum(p => p.TotalWeight * p.UnitPrice!.Value);
    }
}