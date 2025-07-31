using TheFisher.BLL.DTOs;
using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using TheFisher.DAL.enums;
using TheFisher.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TheFisher.BLL.Services;

public class OrderService : IOrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly PurchaseRepository _purchaseRepository;
    private readonly Repository<Item> _itemRepository;
    private readonly Repository<Client> _clientRepository;
    private readonly FisherDbContext _context;

    public OrderService(FisherDbContext context)
    {
        _context = context;
        _orderRepository = new OrderRepository(context);
        _purchaseRepository = new PurchaseRepository(context);
        _itemRepository = new Repository<Item>(context);
        _clientRepository = new Repository<Client>(context);
    }

    public async Task<Order> CreateOrderAsync(OrderCreateDto orderDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Validate item availability
            var availablePurchases = await _purchaseRepository.GetAvailablePurchasesForItemAsync(orderDto.ItemId);
            var totalAvailable = availablePurchases.Sum(p => p.WeightAvailable);

            if (totalAvailable < orderDto.Weight)
            {
                throw new InvalidOperationException($"Insufficient stock. Available: {totalAvailable}kg, Requested: {orderDto.Weight}kg");
            }

            // Create order
            var order = new Order
            {
                ClientId = orderDto.ClientId,
                ItemId = orderDto.ItemId,
                Weight = orderDto.Weight,
                KiloPrice = orderDto.KiloPrice,
                Date = orderDto.Date,
                Total = orderDto.Weight * orderDto.KiloPrice,
                Collected = 0
            };

            await _orderRepository.AddAsync(order);

            // Link order to purchases (FIFO)
            decimal remainingWeight = orderDto.Weight;
            decimal normalStock = 0, commissionedStock = 0;
            
            foreach (var purchase in availablePurchases.OrderBy(p => p.Date))
            {
                if (remainingWeight <= 0) break;

                decimal weightToUse = Math.Min(remainingWeight, purchase.WeightAvailable);
                    
                // Create order-purchase link
                var orderPurchase = new OrderPurchase
                {
                    OrderId = order.Id,
                    PurchaseId = purchase.Id,
                    WeightUsed = weightToUse
                };
                    
                _context.OrderPurchases.Add(orderPurchase);

                // Update purchase available weight
                purchase.WeightAvailable -= weightToUse;
                
                if (purchase.Type == PurchaseType.Direct)
                {
                    normalStock += weightToUse;
                }
                else
                {
                    commissionedStock += weightToUse;
                }
               
                await _purchaseRepository.UpdateAsync(purchase);

                remainingWeight -= weightToUse;
                
                // Update client balance
                var client = await _clientRepository.GetByIdAsync(orderDto.ClientId);
                if (client == null) throw new Exception("Client not found");
                
                client.OutstandingBalance += order.Total * (100 - purchase.CommissionPercent) / 100;
                await _clientRepository.UpdateAsync(client);
            }

            // Update item stock
            var item = await _itemRepository.GetByIdAsync(orderDto.ItemId);
            if (item != null)
            {
                item.Stock -= normalStock;
                item.CommissionedStock -= commissionedStock;
                await _itemRepository.UpdateAsync(item);
            }

            await transaction.CommitAsync();
            return order;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetOrdersWithDetailsAsync();
    }

    public async Task<IEnumerable<Order>> GetTodaysOrdersAsync()
    {
        return await _orderRepository.GetTodaysOrdersAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByClientAsync(int clientId)
    {
        return await _orderRepository.GetOrdersByClientAsync(clientId);
    }

    public async Task<decimal> GetCurrentMonthRevenueAsync()
    {
        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        var orders = await _context.Orders
            .Where(o => o.Date >= startOfMonth && o.Date <= endOfMonth)
            .ToListAsync();

        return orders.Sum(o => o.Total);
    }

    public async Task<decimal> GetMoneyClientsOweAsync()
    {
        var clients = await _context.Clients.ToListAsync();
        return clients.Sum(c => c.OutstandingBalance);
    }
}