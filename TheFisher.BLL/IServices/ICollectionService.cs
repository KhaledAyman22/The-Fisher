using TheFisher.BLL.Dtos;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.IServices;

public interface ICollectionService
{
    Task CreateCollectionAsync(CreateCollectionDto createCollectionDto);
    Task<IEnumerable<GetCollectionDto>> GetTodaysCollectionsAsync();
    Task<IEnumerable<GetCollectionDto>> GetCollectionsByClientAsync(int clientId);
    
    // Statistics methods for dashboard
    Task<decimal> GetCurrentMonthCollectionsAsync();
}