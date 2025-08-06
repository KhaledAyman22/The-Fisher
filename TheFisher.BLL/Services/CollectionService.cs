using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;
using TheFisher.DAL.enums;

namespace TheFisher.BLL.Services;

public class CollectionService(FisherDbContext context, ISalesService salesService) : ICollectionService
{
    public async Task CreateDailyCollectionsAsync(List<CollectionDto> collections)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            foreach (var collection in collections)
            {
                if (collection.Id == Ulid.Empty)
                {
                    await AddCollection(collection);
                }
                else
                {
                    await UpdateCollection(collection);
                }
            }

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private async Task UpdateCollection(CollectionDto collection)
    {
        var client = await context.Clients.FindAsync(collection.ClientId);
        if (client == null) throw new Exception("Client not found");

        var collectionEntity = await context.Collections.FindAsync(collection.Id);
        if (collectionEntity == null) throw new Exception("Collection not found");
        
        client.OutstandingBalance += collectionEntity.Amount;
        client.OutstandingBalance -= collection.Amount;

        collectionEntity.Amount = collection.Amount;
        
        context.Clients.Update(client);
        context.Collections.Update(collectionEntity);
    }

    private async Task AddCollection(CollectionDto collection)
    {
        var client = await context.Clients.FindAsync(collection.ClientId);
        if (client == null) throw new Exception("Client not found");

        client.OutstandingBalance -= collection.Amount;

        var collectionEntity = new Collection
        {
            Id = Ulid.NewUlid(),
            ClientId = collection.ClientId,
            Amount = collection.Amount,
            Date = collection.Date
        };

        context.Clients.Update(client);
        await context.Collections.AddAsync(collectionEntity);
    }

    // public async Task<IEnumerable<GetCollectionDto>> GetTodaysCollectionsAsync()
    // {
    //     var today = DateTime.Today;
    //     return await context.Collections
    //         .Include(c => c.Client)
    //         .Where(c => c.Date.Date == today)
    //         .OrderByDescending(c => c.Date)
    //         .Select(c => new GetCollectionDto(c.Id, c.Client.Name, c.Amount, c.Date))
    //         .ToListAsync();
    // }
    //
    // public async Task<IEnumerable<GetCollectionDto>> GetCollectionsByClientAsync(int clientId)
    // {
    //     return await context.Collections
    //         .Include(c => c.Client)
    //         .Where(c => c.ClientId == clientId)
    //         .OrderByDescending(c => c.Date)
    //         .Select(c => new GetCollectionDto(c.Id, c.Client.Name, c.Amount, c.Date))
    //         .ToListAsync();
    // }
    //
    // public async Task<decimal> GetCurrentMonthCollectionsAsync()
    // {
    //     var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    //     var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
    //
    //     var collections = await context.Collections
    //         .Where(c => c.Date >= startOfMonth && c.Date <= endOfMonth)
    //         .ToListAsync();
    //
    //     return collections.Sum(c => c.Amount);
    // }
}