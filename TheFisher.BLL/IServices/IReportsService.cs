namespace TheFisher.BLL.IServices;

public interface IReportsService
{
    Task<IEnumerable<object>> GetTodaysPurchasesAsync();
    Task<IEnumerable<object>> GetTodaysCollectionsAsync();
    Task<IEnumerable<object>> GetPurchasesByDealerAsync(int dealerId);
    Task<IEnumerable<object>> GetCollectionsByClientAsync(int clientId);
    Task<IEnumerable<object>> GetDealersForFilterAsync();
    Task<IEnumerable<object>> GetClientsForFilterAsync();
} 