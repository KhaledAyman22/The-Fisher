using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.DTOs;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.Managers;

public class CollectionsManager(FisherDbContext context)
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

        client.OutstandingBalance -= collectionDto.Amount;

        var collection = new Collection
        {
            ClientId = collectionDto.ClientId,
            Amount = collectionDto.Amount,
            Date = DateTime.UtcNow
        };
        context.Collections.Add(collection);
        //TODO Update Collection details to reflect the collection on orders
        context.SaveChanges();
    }

    public List<CollectionDto> GetTodaysCollections()
    {
        return context.Collections
            .Include(c => c.Client)
            .Where(c => c.Date.Date == DateTime.UtcNow.Date)
            .Select(c => new CollectionDto
            {
                Id = c.Id,
                ClientName = c.Client.Name,
                Amount = c.Amount,
                Date = c.Date
            })
            .ToList();
    }
}