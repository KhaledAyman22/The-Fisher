using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace TheFisher.BLL.Services;

public class CollectionService(FisherDbContext context) : ICollectionService
{
    public async Task<Collection> CreateCollectionAsync(CollectionCreateDto collectionDto)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var collection = new Collection
            {
                ClientId = collectionDto.ClientId,
                Amount = collectionDto.Amount,
                Date = collectionDto.Date
            };

            await context.Collections.AddAsync(collection);

            // Create collection details and update orders
            foreach (var payment in collectionDto.OrderPayments)
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
            var client = await context.Clients.FindAsync(collectionDto.ClientId);
            if (client != null)
            {
                client.OutstandingBalance -= collectionDto.Amount;
                context.Clients.Update(client);
            }

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            return collection;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<Collection>> GetAllCollectionsAsync()
    {
        return await context.Collections
            .Include(c => c.Client)
            .Include(c => c.CollectionDetails)
            .ThenInclude(cd => cd.Order)
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Collection>> GetTodaysCollectionsAsync()
    {
        var today = DateTime.Today;
        return await context.Collections
            .Include(c => c.Client)
            .Where(c => c.Date.Date == today)
            .OrderByDescending(c => c.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Collection>> GetCollectionsByClientAsync(int clientId)
    {
        return await context.Collections
            .Include(c => c.Client)
            .Where(c => c.ClientId == clientId)
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