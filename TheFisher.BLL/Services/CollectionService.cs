using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;

namespace TheFisher.BLL.Services;

public class CollectionService(FisherDbContext context) : ICollectionService
{
    public async Task CreateCollectionAsync(CreateCollectionDto createCollectionDto)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var collection = new Collection
            {
                ClientId = createCollectionDto.ClientId,
                Amount = createCollectionDto.Amount,
                Date = createCollectionDto.Date
            };

            await context.Collections.AddAsync(collection);

            // Create collection details and update orders
            foreach (var payment in createCollectionDto.OrderPayments)
            {
                var collectionDetail = new CollectionDetail
                {
                    CollectionId = collection.Id,
                    OrderId = payment.OrderId,
                    Amount = payment.Amount
                };
                    
                context.CollectionDetails.Add(collectionDetail);

                // Update order collected amount
                var order = await context.Orders.FindAsync(payment.OrderId);
                if (order == null) continue;
                order.Collected += payment.Amount;
                context.Orders.Update(order);
            }

            // Update client balance
            var client = await context.Clients.FindAsync(createCollectionDto.ClientId);
            if (client != null)
            {
                client.OutstandingBalance -= createCollectionDto.Amount;
                context.Clients.Update(client);
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

    public async Task<IEnumerable<GetCollectionDto>> GetTodaysCollectionsAsync()
    {
        var today = DateTime.Today;
        return await context.Collections
            .Include(c => c.Client)
            .Where(c => c.Date.Date == today)
            .Select(c => new GetCollectionDto(c.Id, c.Client.Name, c.Amount, c.Date))
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<GetCollectionDto>> GetCollectionsByClientAsync(int clientId)
    {
        return await context.Collections
            .Include(c => c.Client)
            .Where(c => c.ClientId == clientId)
            .Select(c => new GetCollectionDto(c.Id, c.Client.Name, c.Amount, c.Date))
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }

    public async Task<decimal> GetCurrentMonthCollectionsAsync()
    {
        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        var collections = await context.Collections
            .Where(c => c.Date >= startOfMonth && c.Date <= endOfMonth)
            .ToListAsync();

        return collections.Sum(c => c.Amount);
    }
}