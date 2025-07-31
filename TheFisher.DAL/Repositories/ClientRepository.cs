using Microsoft.EntityFrameworkCore;
using TheFisher.DAL.Entities;

namespace TheFisher.DAL.Repositories;

public class ClientRepository : Repository<Client>
{
    public ClientRepository(FisherDbContext context) : base(context) { }

    public async Task<IEnumerable<Client>> GetClientsWithOrdersAsync()
    {
        return await _context.Clients
            .Include(c => c.Orders)
            .Include(c => c.Collections)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }
}