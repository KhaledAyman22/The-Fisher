using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.DTOs;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.Managers;

public class CollectionManager(FisherDbContext context)
{
    public void AddCollection(CreateCollectionDto collectionDto)
    {
        if (collectionDto.Amount <= 0)
        {
            throw new ValidationException("Collection amount must be positive.");
        }

        var client = context.Clients.Find(collectionDto.ClientId);
        if (client == null)
        {
            throw new ValidationException("Invalid Client ID.");
        }
            
        using var transaction = context.Database.BeginTransaction();

        try
        {
            // 1. Create the main collection record
            var collection = new Collection
            {
                ClientId = collectionDto.ClientId,
                Amount = collectionDto.Amount,
                Date = DateTime.UtcNow
            };
            context.Collections.Add(collection);
            context.SaveChanges(); // Save to get the collection ID

            // 2. Find unpaid orders for the client, oldest first
            var unpaidOrders = context.Orders
                .Where(o => o.ClientId == collectionDto.ClientId && o.Total > o.Collected)
                .OrderBy(o => o.Date)
                .ToList();

            var amountToApply = collectionDto.Amount;

            // 3. Distribute the collection amount across unpaid orders
            foreach (var order in unpaidOrders)
            {
                if (amountToApply <= 0) break;

                var dueAmount = order.Total - order.Collected;
                var payment = Math.Min(amountToApply, dueAmount);

                var detail = new CollectionDetail
                {
                    CollectionId = collection.Id,
                    OrderId = order.Id,
                    Amount = payment
                };
                context.CollectionDetails.Add(detail);
                    
                order.Collected += payment;
                amountToApply -= payment;
            }

            // 4. Update client's balance and save all changes
            client.OutstandingBalance -= collectionDto.Amount;
            context.SaveChanges();
                
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            // Consider logging the exception
            throw new Exception("An error occurred while processing the collection.", ex);
        }
    }
        
    // GetTodaysCollections method remains the same
    public List<CollectionDto> GetTodaysCollections()
    {
        var collections = context.Collections
            .Include(c => c.Client)
            .Where(c => c.Date.Date == DateTime.UtcNow.Date)
            .ToList();

        return collections.Select(c => new CollectionDto
        {
            Id = c.Id,
            ClientName = c.Client?.Name ?? throw new Exception("Unknown Client"),
            Amount = c.Amount,
            Date = c.Date
        }).ToList();
    }
    
    public List<CollectionDto> GetCollectionsByClient(int clientId)
    {
        var collections = context.Collections
            .Where(c => c.ClientId == clientId)
            .Include(c => c.Client)
            .ToList();

        return collections.Select(c => new CollectionDto
        {
            Id = c.Id,
            ClientName = c.Client?.Name ?? throw new Exception("Unknown Client"),
            Amount = c.Amount,
            Date = c.Date
        }).ToList();
    }
}