using TheFisher.BLL.Dtos;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.IServices;

public interface ISalesService
{
    Task CreateDailySalesAsync(int clientId, List<SalesDto> sales);
    Task<IEnumerable<GetOrderDto>> GetTodaysOrdersAsync();
    Task<IEnumerable<GetOrderDto>> GetOrdersByClientAsync(int clientId);
    
    // Statistics methods for dashboard
    Task<decimal> GetCurrentMonthRevenueAsync();
    Task<decimal> GetMoneyClientsOweAsync();
}