using TheFisher.BLL.DTOs;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.IServices;

public interface IPurchaseService
{
    Task<Purchase> CreatePurchaseAsync(PurchaseCreateDto purchaseDto);
    Task<IEnumerable<Purchase>> GetAllPurchasesAsync();
    Task<IEnumerable<Purchase>> GetTodaysPurchasesAsync();
    Task<IEnumerable<Purchase>> GetPurchasesByDealerAsync(int dealerId);
    
    // Statistics methods for dashboard
    Task<decimal> GetMoneyOwedToDealersAsync();
}