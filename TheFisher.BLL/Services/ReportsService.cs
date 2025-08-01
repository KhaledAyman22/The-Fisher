using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.enums;

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
            
            
            .Where(p => p.Date.Date == DateTime.Today)
            .Select(p => new
            {
                p.Id,
                Dealer = p.Dealer.Name,
                Item = p.Item.Name,
                p.TotalUnits,
                UnitPrice = p.UnitPrice ?? 0,
                p.TotalWeight,
                p.WeightAvailable,
                p.Type,
                p.Date,
                Cost = p.Type == PurchaseType.Direct? (p.TotalWeight * p.UnitPrice) : 0
            })
            .OrderByDescending(p => p.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetTodaysCollectionsAsync()
    {
        return await _context.Collections
            
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
            
            
            .Where(p => p.DealerId == dealerId)
            .Select(p => new
            {
                p.Id,
                Item = p.Item.Name,
                p.TotalUnits,
                UnitPrice = p.UnitPrice ?? 0,
                p.TotalWeight,
                p.WeightAvailable,
                p.Type,
                p.Date,
                Cost = p.Type == PurchaseType.Direct? (p.TotalWeight * p.UnitPrice) : 0
            })
            .OrderByDescending(p => p.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetCollectionsByClientAsync(int clientId)
    {
        return await _context.Collections
            
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

    public async Task<IEnumerable<object>> GetBalanceStatementCombined()
    {
        return await _context.Clients
            .Select(c => new
            {
                Client = c.Name,
                Outstanding = c.OutstandingBalance - c.Orders.Where(o => o.Date == DateTime.Now.AddDays(-1).Date).Sum(o => o.Total),
                New = c.Orders.Where(o => o.Date == DateTime.Now.AddDays(-1).Date).Sum(o => o.Total)
            }).ToListAsync();
    }
    
    public async Task<IEnumerable<object>> GetClientBalanceStatement(int clientId, DateTime startDate, DateTime endDate)
    {
        return _context.Clients
            .Where(c => c.Orders.Any(o => o.Date >= startDate && o.Date <= endDate))
            .Select(c => new
            {
                Client = c.Name,
                Outstanding = c.OutstandingBalance - c.Orders.Where(o => o.Date == DateTime.Now.AddDays(-1).Date).Sum(o => o.Total),
                New = c.Orders.Where(o => o.Date == DateTime.Now.AddDays(-1).Date).Sum(o => o.Total)
            });
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