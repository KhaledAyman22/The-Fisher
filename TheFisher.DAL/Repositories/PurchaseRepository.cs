using Microsoft.EntityFrameworkCore;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Repositories;

public class PurchaseRepository : Repository<Purchase>
{
    public PurchaseRepository(FisherDbContext context) : base(context) { }

    public async Task<IEnumerable<Purchase>> GetPurchasesWithDetailsAsync()
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

    public async Task<IEnumerable<Purchase>> GetAvailablePurchasesForItemAsync(int itemId)
    {
        return await _context.Purchases
            .Include(p => p.Dealer)
            .Include(p => p.Item)
            .Where(p => p.ItemId == itemId && p.WeightAvailable > 0)
            .OrderBy(p => p.Date) // FIFO
            .ToListAsync();
    }
}