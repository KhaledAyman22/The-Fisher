using TheFisher.BLL.DTOs;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.IServices;

public interface ICollectionService
{
    Task<Collection> CreateCollectionAsync(CollectionCreateDto collectionDto);
    Task<IEnumerable<Collection>> GetAllCollectionsAsync();
    Task<IEnumerable<Collection>> GetTodaysCollectionsAsync();
    Task<IEnumerable<Collection>> GetCollectionsByClientAsync(int clientId);
    
    // Statistics methods for dashboard
    Task<decimal> GetCurrentMonthCollectionsAsync();
}