using TheFisher.BLL.Dtos;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.IServices;

public interface IPurchaseService
{
    Task CreateDailyPurchasesAsync(List<PurchaseDto> purchases);
    Task<IEnumerable<PurchaseDto>> GetPurchasesAsync(DateTime date, int dealerId);
}