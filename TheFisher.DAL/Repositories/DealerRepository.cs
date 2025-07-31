using Microsoft.EntityFrameworkCore;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Repositories;

public class DealerRepository : Repository<Dealer>
{
    public DealerRepository(FisherDbContext context) : base(context) { }

    public async Task<IEnumerable<Dealer>> GetDealersWithPurchasesAsync()
    {
        return await _context.Dealers
            .Include(d => d.Purchases)
            .OrderBy(d => d.Name)
            .ToListAsync();
    }
}