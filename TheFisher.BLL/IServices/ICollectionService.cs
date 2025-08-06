using TheFisher.BLL.Dtos;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.IServices;

public interface ICollectionService
{
    Task CreateDailyCollectionsAsync(List<CollectionDto> collections);
    // Task<IEnumerable<GetCollectionDto>> GetTodaysCollectionsAsync();
    // Task<IEnumerable<GetCollectionDto>> GetCollectionsByClientAsync(int clientId);
    //
    // // Statistics methods for dashboard
    // Task<decimal> GetCurrentMonthCollectionsAsync();
}