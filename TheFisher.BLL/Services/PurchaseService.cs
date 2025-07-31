using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using TheFisher.DAL.enums;
using TheFisher.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TheFisher.BLL.Services;

public class PurchaseService : IPurchaseService
{
    private readonly PurchaseRepository _purchaseRepository;
    private readonly Repository<Item> _itemRepository;
    private readonly FisherDbContext _context;

    public PurchaseService(FisherDbContext context)
    {
        _context = context;
        _purchaseRepository = new PurchaseRepository(context);
        _itemRepository = new Repository<Item>(context);
    }

    public async Task<Purchase> CreatePurchaseAsync(PurchaseCreateDto purchaseDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var purchase = new Purchase
            {
                DealerId = purchaseDto.DealerId,
                ItemId = purchaseDto.ItemId,
                TotalUnits = purchaseDto.TotalUnits,
                UnitPrice = purchaseDto.KiloPrice,
                TotalWeight = purchaseDto.TotalWeight,
                WeightAvailable = purchaseDto.TotalWeight,
                Type = purchaseDto.Type,
                Date = purchaseDto.Date
            };

            await _purchaseRepository.AddAsync(purchase);

            // Update item stock and average price
            var item = await _itemRepository.GetByIdAsync(purchaseDto.ItemId);
            if (item == null)
            {
                throw new Exception("Item not found");
            }

            if (purchaseDto.Type == PurchaseType.Direct)
            {
                // Update average price (weighted average)
                var totalValue = (item.Stock * item.AvgPricePerKg) + (purchaseDto.TotalWeight * purchaseDto.KiloPrice!.Value);
                var totalWeight = item.Stock + purchaseDto.TotalWeight;

                if (totalWeight > 0)
                {
                    item.AvgPricePerKg = totalValue / totalWeight;
                }

                item.Stock += purchaseDto.TotalWeight;
            }
            else
            {
                item.CommissionedStock += purchaseDto.TotalWeight;
            }

            await _itemRepository.UpdateAsync(item);

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
        return await _purchaseRepository.GetPurchasesWithDetailsAsync();
    }

    public async Task<IEnumerable<Purchase>> GetTodaysPurchasesAsync()
    {
        return await _purchaseRepository.GetTodaysPurchasesAsync();
    }

    public async Task<IEnumerable<Purchase>> GetPurchasesByDealerAsync(int dealerId)
    {
        return await _purchaseRepository.GetPurchasesByDealerAsync(dealerId);
    }

    public async Task<decimal> GetMoneyOwedToDealersAsync()
    {
        var purchases = await _context.Purchases
            .Where(p => p.Type == PurchaseType.Direct && p.UnitPrice.HasValue)
            .ToListAsync();

        return purchases.Sum(p => p.TotalWeight * p.UnitPrice!.Value);
    }
}