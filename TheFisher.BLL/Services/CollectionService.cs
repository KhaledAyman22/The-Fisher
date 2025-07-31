using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using TheFisher.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TheFisher.BLL.Services;

public class CollectionService : ICollectionService
{
    private readonly CollectionRepository _collectionRepository;
    private readonly OrderRepository _orderRepository;
    private readonly Repository<Client> _clientRepository;
    private readonly FisherDbContext _context;

    public CollectionService(FisherDbContext context)
    {
        _context = context;
        _collectionRepository = new CollectionRepository(context);
        _orderRepository = new OrderRepository(context);
        _clientRepository = new Repository<Client>(context);
    }

    public async Task<Collection> CreateCollectionAsync(CollectionCreateDto collectionDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var collection = new Collection
            {
                ClientId = collectionDto.ClientId,
                Amount = collectionDto.Amount,
                Date = collectionDto.Date
            };

            await _collectionRepository.AddAsync(collection);

            // Create collection details and update orders
            foreach (var payment in collectionDto.OrderPayments)
            {
                var collectionDetail = new CollectionDetail
                {
                    CollectionId = collection.Id,
                    OrderId = payment.OrderId,
                    Amount = payment.Amount
                };
                    
                _context.CollectionDetails.Add(collectionDetail);

                // Update order collected amount
                var order = await _orderRepository.GetByIdAsync(payment.OrderId);
                if (order == null) continue;
                order.Collected += payment.Amount;
                await _orderRepository.UpdateAsync(order);
            }

            // Update client balance
            var client = await _clientRepository.GetByIdAsync(collectionDto.ClientId);
            if (client != null)
            {
                client.OutstandingBalance -= collectionDto.Amount;
                await _clientRepository.UpdateAsync(client);
            }

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
        return await _collectionRepository.GetCollectionsWithDetailsAsync();
    }

    public async Task<IEnumerable<Collection>> GetTodaysCollectionsAsync()
    {
        return await _collectionRepository.GetTodaysCollectionsAsync();
    }

    public async Task<IEnumerable<Collection>> GetCollectionsByClientAsync(int clientId)
    {
        return await _collectionRepository.GetCollectionsByClientAsync(clientId);
    }

    public async Task<decimal> GetCurrentMonthCollectionsAsync()
    {
        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        var collections = await _context.Collections
            .Where(c => c.Date >= startOfMonth && c.Date <= endOfMonth)
            .ToListAsync();

        return collections.Sum(c => c.Amount);
    }
}