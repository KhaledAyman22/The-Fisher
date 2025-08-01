using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;
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

    public async Task<IEnumerable<GetPurchaseDto>> GetTodaysPurchasesAsync()
    {
        return await _context.Purchases
            .Where(p => p.Date.Date == DateTime.Today)
            .OrderByDescending(p => p.Date)
            .Select(p => new GetPurchaseDto(
                p.Id,
                p.Dealer.Name,
                p.Item.Name,
                p.TotalUnits,
                p.UnitPrice ?? 0,
                p.TotalWeight,
                p.Type,
                DateTime.Today,
                p.TransportationFees,
                p.Tax
            ))
            .ToListAsync();
    }

    public async Task<IEnumerable<GetCollectionDto>> GetTodaysCollectionsAsync()
    {
        return await _context.Collections
            .Where(c => c.Date.Date == DateTime.Today)
            .OrderByDescending(c => c.Date)
            .Select(c => new GetCollectionDto(
                c.Id,
                c.Client.Name,
                c.Amount,
                c.Date
            ))
            .ToListAsync();
    }

    public async Task<IEnumerable<GetPurchaseDto>> GetPurchasesByDealerAsync(int dealerId)
    {
        return await _context.Purchases
            .Where(p => p.DealerId == dealerId)
            .OrderByDescending(p => p.Date)
            .Select(p => new GetPurchaseDto(
                p.Id,
                p.Dealer.Name,
                p.Item.Name,
                p.TotalUnits,
                p.UnitPrice ?? 0,
                p.TotalWeight,
                p.Type,
                DateTime.Today,
                p.TransportationFees,
                p.Tax
            ))
            .ToListAsync();
    }

    public async Task<IEnumerable<GetCollectionDto>> GetCollectionsByClientAsync(int clientId)
    {
        return await _context.Collections
            .Where(c => c.ClientId == clientId)
            .OrderByDescending(c => c.Date)
            .Select(c => new GetCollectionDto(
                c.Id,
                c.Client.Name,
                c.Amount,
                c.Date
            ))
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientBalanceDto>> GetBalanceStatementCombined(DateTime date)
    {
        return await _context.Clients
            .Select(c => new ClientBalanceDto(
                c.Name,
                c.OutstandingBalance - c.Orders.Where(o => o.Date >= date).Sum(o => o.Total),
                c.Orders.Where(o => o.Date == date).Sum(o => o.Total)
            )).ToListAsync();
    }

    public async Task<IEnumerable<ClientBalanceDto>> GetClientBalanceStatement(int clientId, DateTime startDate,
        DateTime endDate)
    {
        return await _context.Clients
            .Where(c => c.Id == clientId && c.Orders.Any(o => o.Date >= startDate && o.Date <= endDate))
            .Select(c => new ClientBalanceDto(
                c.Name,
                c.OutstandingBalance - c.Orders.Where(o => o.Date == DateTime.Now.AddDays(-1).Date).Sum(o => o.Total),
                c.Orders.Where(o => o.Date == DateTime.Now.AddDays(-1).Date).Sum(o => o.Total)
            ))
            .ToListAsync();
    }


    public async Task<IEnumerable<DealerDropDownDto>> GetDealersForFilterAsync()
    {
        return await _context.Dealers
            .OrderBy(d => d.Name)
            .Select(d => new DealerDropDownDto(d.Id, d.Name))
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientDropDownDto>> GetClientsForFilterAsync()
    {
        return await _context.Clients
            .OrderBy(c => c.Name)
            .Select(c => new ClientDropDownDto(c.Id, c.Name))
            .ToListAsync();
    }
}