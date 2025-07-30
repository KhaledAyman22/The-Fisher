using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.DTOs;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.Managers;

public class OrderManager(FisherDbContext context)
{
    public void AddOrder(CreateOrderDto orderDto)
    {
        if (orderDto.Units <= 0 || orderDto.UnitPrice <= 0)
        {
            throw new ValidationException("Units and Unit Price must be positive.");
        }

        var client = context.Clients.Find(orderDto.ClientId);
        if (client == null)
        {
            throw new ValidationException("Invalid Client ID.");
        }

        var order = new Order
        {
            ClientId = orderDto.ClientId,
            ItemId = orderDto.ItemId,
            Units = orderDto.Units,
            UnitPrice = orderDto.UnitPrice,
            Date = DateTime.UtcNow,
            Collected = 0
        };

        client.OutstandingBalance += order.Total;

        context.Orders.Add(order);
        context.SaveChanges();
    }

    public List<OrderDto> GetTodaysOrders()
    {
        return context.Orders
            .Include(o => o.Client)
            .Include(o => o.Item)
            .Where(o => o.Date.Date == DateTime.UtcNow.Date)
            .Select(o => new OrderDto
            {
                Id = o.Id,
                ClientName = o.Client.Name,
                ItemName = o.Item.Name,
                Units = o.Units,
                UnitPrice = o.UnitPrice,
                Total = o.Total,
                Collected = o.Collected,
                Date = o.Date
            })
            .ToList();
    }
}