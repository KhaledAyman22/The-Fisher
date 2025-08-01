using TheFisher.BLL.Dtos;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.IServices;

public interface IPurchaseService
{
    Task<Purchase> CreatePurchaseAsync(PurchaseCreateDto purchaseCreateDto);
    Task<IEnumerable<Purchase>> GetTodaysPurchasesAsync();
    Task<IEnumerable<Purchase>> GetPurchasesByDealerAsync(int dealerId);
    
    // Statistics methods for dashboard
    Task<decimal> GetMoneyOwedToDealersAsync();
}