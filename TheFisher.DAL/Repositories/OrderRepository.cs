using Microsoft.EntityFrameworkCore;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Repositories;

public class OrderRepository : Repository<Order>
{
    public OrderRepository(FisherDbContext context) : base(context) { }

    public async Task<IEnumerable<Order>> GetOrdersWithDetailsAsync()
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Item)
            .Include(o => o.CollectionDetails)
            .OrderByDescending(o => o.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetTodaysOrdersAsync()
    {
        var today = DateTime.Today;
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Item)
            .Where(o => o.Date.Date == today)
            .OrderByDescending(o => o.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByClientAsync(int clientId)
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Item)
            .Where(o => o.ClientId == clientId)
            .OrderByDescending(o => o.Date)
            .ToListAsync();
    }
}