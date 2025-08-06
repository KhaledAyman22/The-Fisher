using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using TheFisher.DAL.enums;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;

namespace TheFisher.BLL.Services;

public class SalesService(FisherDbContext context) : ISalesService
{
    public async Task CreateDailySalesAsync(int clientId, List<SalesDto> sales)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            foreach (var sale in sales)
            {
                if (sale.Id == Ulid.Empty)
                    await CreateSale(clientId, sale);
                else
                    await UpdateSale(clientId, sale);
            }

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private async Task CreateSale(int dealerId, SalesDto sale)
    {
        var dealer = await context.Dealers.FindAsync(dealerId)
                     ?? throw new Exception("Dealer not found");

        var dealerItem = await context.DealerItems
                             .FindAsync(new { DealerId = dealerId, sale.ItemId })
                         ?? throw new Exception("No stock for this item from the given dealer");

        var item = await context.Items.FindAsync(sale.ItemId)
                   ?? throw new Exception("Item not found");

        var client = await context.Clients.FindAsync(sale.ClientId)
                     ?? throw new Exception("Client not found");

        decimal total = sale.Units * sale.UnitPrice + sale.Tax;
        decimal profit;

        if (dealer.Type == PurchaseType.Direct)
        {
            if (dealerItem.Stock < sale.Units)
                throw new InvalidOperationException($"Insufficient stock: {dealerItem.Stock}kg");

            dealerItem.Stock -= sale.Units;
            item.InHouseStock -= sale.Units;
            profit = total - sale.Units * item.AveragePrice;
        }
        else
        {
            if (dealerItem.CommissionedStock < sale.Units)
                throw new InvalidOperationException(
                    $"Insufficient commissioned stock: {dealerItem.CommissionedStock}kg");

            dealerItem.CommissionedStock -= sale.Units;
            profit = total * sale.CommissionPercent!.Value / 100;
        }

        // Update entities
        context.Update(dealerItem);
        context.Update(item);

        client.OutstandingBalance += total;
        context.Update(client);

        var saleEntity = new Sale
        {
            Id = Ulid.NewUlid(),
            ClientId = dealerId,
            ItemId = sale.ItemId,
            Units = sale.Units,
            UnitPrice = sale.UnitPrice,
            Date = sale.Date,
            Collected = 0,
            Tax = sale.Tax,
            Profit = profit,
            Total = total
        };

        await context.Sales.AddAsync(saleEntity);
    }

    private async Task UpdateSale(int dealerId, SalesDto sale)
    {
        var saleEntity = await context.Sales.FindAsync(sale.Id)
                      ?? throw new Exception("Sale not found");

        // Reverse old sale
        var oldDealer = await context.Dealers.FindAsync(saleEntity.DealerId)
                        ?? throw new Exception("Old dealer not found");

        var oldClient = await context.Clients.FindAsync(saleEntity.ClientId)
                        ?? throw new Exception("Old client not found");

        var oldItem = await context.Items.FindAsync(saleEntity.ItemId)
                      ?? throw new Exception("Old item not found");

        var oldDealerItem = await context.DealerItems.FindAsync(new { saleEntity.DealerId, saleEntity.ItemId })
                            ?? throw new Exception("Old dealer item not found");

        
        // Revert client balance
        oldClient.OutstandingBalance -= saleEntity.Total;
        
        // Revert dealer stock
        if (oldDealer.Type == PurchaseType.Direct)
        {
            oldDealerItem.Stock += saleEntity.Units;
            // Revert item stock
            oldItem.InHouseStock += saleEntity.Units;
            
            if(oldItem.InHouseStock == 0)
                oldItem.AveragePrice = 0;
        }
        else
        {
            oldDealerItem.CommissionedStock += saleEntity.Units;
        }

        // Apply new sale
        var newDealer = await context.Dealers.FindAsync(dealerId)
                        ?? throw new Exception("New dealer not found");

        var newClient = await context.Clients.FindAsync(sale.ClientId)
                        ?? throw new Exception("New client not found");

        var newItem = await context.Items.FindAsync(sale.ItemId)
                      ?? throw new Exception("New item not found");

        var newDealerItem = await context.DealerItems.FindAsync(new { dealerId, sale.ItemId })
                            ?? throw new Exception("New dealer item not found");

        // Check stock
        if (newDealer.Type == PurchaseType.Direct && newDealerItem.Stock < sale.Units)
            throw new Exception("Not enough dealer stock");
        
        if (newDealer.Type == PurchaseType.Commission && newDealerItem.CommissionedStock < sale.Units)
            throw new Exception("Not enough commissioned stock");

        var newTotal = sale.Units * sale.UnitPrice + sale.Tax;
        var profit = 0m;
        newClient.OutstandingBalance += newTotal;
        
        // Subtract stock
        if (newDealer.Type == PurchaseType.Direct)
        {
            newDealerItem.Stock -= sale.Units;
            newItem.InHouseStock -= sale.Units;
            if(newItem.InHouseStock == 0)
                newItem.AveragePrice = 0;
            profit = newTotal - sale.Units * newItem.AveragePrice;
        }
        else
        {
            newDealerItem.CommissionedStock -= sale.Units;
            profit = newTotal * sale.CommissionPercent!.Value / 100;
        }

        // Update sale entity
        saleEntity.ClientId = sale.ClientId;
        saleEntity.ItemId = sale.ItemId;
        saleEntity.DealerId = dealerId;
        saleEntity.Units = sale.Units;
        saleEntity.UnitPrice = sale.UnitPrice;
        saleEntity.Total = newTotal;
        saleEntity.Date = sale.Date;
        saleEntity.Profit = profit;
            
        await context.SaveChangesAsync();
    }


    public async Task<IEnumerable<GetOrderDto>> GetTodaysOrdersAsync()
    {
        var today = DateTime.Today;
        return await context.Sales
            .Where(o => o.Date.Date == today)
            .OrderByDescending(o => o.Date)
            .Select(o =>
                new GetOrderDto(o.Id, o.Client.Name, o.Item.Name, o.Units, o.UnitPrice, o.Date, o.Tax, o.Total))
            .ToListAsync();
    }

    public async Task<IEnumerable<GetOrderDto>> GetOrdersByClientAsync(int clientId)
    {
        return await context.Sales
            .Include(o => o.Client)
            .Include(o => o.Item)
            .Where(o => o.ClientId == clientId)
            .OrderByDescending(o => o.Date)
            .Select(o =>
                new GetOrderDto(o.Id, o.Client.Name, o.Item.Name, o.Units, o.UnitPrice, o.Date, o.Tax, o.Total))
            .ToListAsync();
    }

    public async Task<decimal> GetCurrentMonthRevenueAsync()
    {
        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        var orders = await context.Sales
            .Where(o => o.Date >= startOfMonth && o.Date <= endOfMonth)
            .ToListAsync();

        return orders.Sum(o => o.Total);
    }

    public async Task<decimal> GetMoneyClientsOweAsync()
    {
        var clients = await context.Clients.ToListAsync();
        return clients.Sum(c => c.OutstandingBalance);
    }
}