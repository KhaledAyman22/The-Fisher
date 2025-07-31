using TheFisher.BLL.DTOs;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.IServices;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(OrderCreateDto orderDto);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<IEnumerable<Order>> GetTodaysOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersByClientAsync(int clientId);
    
    // Statistics methods for dashboard
    Task<decimal> GetCurrentMonthRevenueAsync();
    Task<decimal> GetMoneyClientsOweAsync();
    Task<IEnumerable<object>> GetClientUnpaidOrdersAsync(int clientId);
}