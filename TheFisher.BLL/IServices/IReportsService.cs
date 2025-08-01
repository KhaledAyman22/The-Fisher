using TheFisher.BLL.Dtos;

namespace TheFisher.BLL.IServices;

public interface IReportsService
{
    Task<IEnumerable<GetPurchaseDto>> GetTodaysPurchasesAsync();
    Task<IEnumerable<GetCollectionDto>> GetTodaysCollectionsAsync();
    Task<IEnumerable<GetPurchaseDto>> GetPurchasesByDealerAsync(int dealerId);
    Task<IEnumerable<GetCollectionDto>> GetCollectionsByClientAsync(int clientId);
    Task<IEnumerable<DealerDropDownDto>> GetDealersForFilterAsync();
    Task<IEnumerable<ClientDropDownDto>> GetClientsForFilterAsync();
} 