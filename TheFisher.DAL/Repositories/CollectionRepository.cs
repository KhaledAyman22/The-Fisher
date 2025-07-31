using Microsoft.EntityFrameworkCore;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Repositories;

public class CollectionRepository : Repository<Collection>
{
    public CollectionRepository(FisherDbContext context) : base(context) { }

    public async Task<IEnumerable<Collection>> GetCollectionsWithDetailsAsync()
    {
        return await _context.Collections
            .Include(c => c.Client)
            .Include(c => c.CollectionDetails)
            .ThenInclude(cd => cd.Order)
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Collection>> GetTodaysCollectionsAsync()
    {
        var today = DateTime.Today;
        return await _context.Collections
            .Include(c => c.Client)
            .Where(c => c.Date.Date == today)
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Collection>> GetCollectionsByClientAsync(int clientId)
    {
        return await _context.Collections
            .Include(c => c.Client)
            .Where(c => c.ClientId == clientId)
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }
}