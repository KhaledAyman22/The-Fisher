using TheFisher.BLL.Dtos;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.IServices;

public interface IOrderService
{
    Task CreateOrderAsync(OrderCreateDto orderDto);
    Task<IEnumerable<GetOrderDto>> GetTodaysOrdersAsync();
    Task<IEnumerable<GetOrderDto>> GetOrdersByClientAsync(int clientId);
    
    // Statistics methods for dashboard
    Task<decimal> GetCurrentMonthRevenueAsync();
    Task<decimal> GetMoneyClientsOweAsync();
}