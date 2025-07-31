using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.IServices;
using TheFisher.DAL;

namespace TheFisher.BLL.Services;

public class ReportsService : IReportsService
{
    private readonly FisherDbContext _context;

    public ReportsService(FisherDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetTodaysPurchasesAsync()
    {
        return await _context.Purchases
            .Include(p => p.Dealer)
            .Include(p => p.Item)
            .Where(p => p.Date.Date == DateTime.Today)
            .Select(p => new
            {
                p.Id,
                Dealer = p.Dealer.Name,
                Item = p.Item.Name,
                p.TotalUnits,
                p.UnitPrice,
                p.TotalWeight,
                p.WeightAvailable,
                p.Type,
                p.Date
            })
            .OrderByDescending(p => p.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetTodaysCollectionsAsync()
    {
        return await _context.Collections
            .Include(c => c.Client)
            .Where(c => c.Date.Date == DateTime.Today)
            .Select(c => new
            {
                c.Id,
                Client = c.Client.Name,
                c.Amount,
                c.Date
            })
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetPurchasesByDealerAsync(int dealerId)
    {
        return await _context.Purchases
            .Include(p => p.Dealer)
            .Include(p => p.Item)
            .Where(p => p.DealerId == dealerId)
            .Select(p => new
            {
                p.Id,
                Item = p.Item.Name,
                p.TotalUnits,
                p.UnitPrice,
                p.TotalWeight,
                p.WeightAvailable,
                p.Type,
                p.Date
            })
            .OrderByDescending(p => p.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetCollectionsByClientAsync(int clientId)
    {
        return await _context.Collections
            .Include(c => c.Client)
            .Where(c => c.ClientId == clientId)
            .Select(c => new
            {
                c.Id,
                c.Amount,
                c.Date
            })
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetDealersForFilterAsync()
    {
        return await _context.Dealers
            .OrderBy(d => d.Name)
            .Select(d => new { d.Id, d.Name })
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetClientsForFilterAsync()
    {
        return await _context.Clients
            .OrderBy(c => c.Name)
            .Select(c => new { c.Id, c.Name })
            .ToListAsync();
    }
} 