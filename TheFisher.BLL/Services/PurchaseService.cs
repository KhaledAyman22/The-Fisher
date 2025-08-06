using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;
using TheFisher.DAL.enums;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;

namespace TheFisher.BLL.Services;

public class PurchaseService(FisherDbContext context) : IPurchaseService
{
    public async Task CreateDailyPurchasesAsync(List<PurchaseDto> purchases)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            foreach (var purchase in purchases)
            {
                if (purchase.Id == Ulid.Empty)
                {
                    await AddPurchase(purchase);
                }
                else
                {
                    await UpdatePurchase(purchase);
                }
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

    public async Task<IEnumerable<PurchaseDto>> GetPurchasesAsync(DateTime date, int dealerId)
    {
        var today = DateTime.Today;
        return await context.Purchases
            .Where(p => p.DealerId == dealerId)
            .Where(p => p.Date.Date == today)
            .Select(p => new PurchaseDto
            {
                Id = p.Id, 
                DealerId = p.DealerId, 
                DealerName = p.Dealer.Name, 
                ItemId = p.ItemId, 
                ItemName = p.Item.Name,
                Boxes = p.Boxes,
                UnitPrice = p.UnitPrice,
                Units = p.Units, 
                Date = p.Date, 
                Tax = p.Tax,
                TransportationFees = p.TransportationFees
            })
            .ToListAsync();
    }

    private async Task AddPurchase(PurchaseDto purchase)
    {
        var item = await context.Items.FindAsync(purchase.ItemId);
        if (item == null)
        {
            throw new Exception("Item not found");
        }

        var dealer = await context.Dealers.FindAsync(purchase.DealerId);
        if (dealer == null)
        {
            throw new Exception("Dealer not found");
        }

        var dealerItem = await context.DealerItems.Where(di => di.DealerId == dealer.Id && di.ItemId == item.Id)
                             .FirstOrDefaultAsync() ??
                         new DealerItem()
                         {
                             DealerId = purchase.DealerId,
                             ItemId = purchase.ItemId
                         };

        //TODO Check if required
        dealer.OutstandingBalance -= purchase.TransportationFees ?? 0;

        decimal actualKiloPrice = 0m;
        if (purchase.UnitPrice.HasValue)
        {
            actualKiloPrice = purchase.UnitPrice.Value +
                              (purchase.Tax!.Value / purchase.Units);
        }

        if (dealer.Type == PurchaseType.Direct)
        {
            item.AveragePrice = (item.AveragePrice * item.InHouseStock + actualKiloPrice * purchase.Units) /
                                (item.InHouseStock + purchase.Units);

            item.InHouseStock += purchase.Units;
        }
        else
        {
            dealerItem.CommissionedStock += purchase.Units;
        }

        var purchaseEntity = new Purchase
        {
            Id = Ulid.NewUlid(),
            DealerId = purchase.DealerId,
            ItemId = purchase.ItemId,
            Boxes = purchase.Boxes,
            UnitPrice = purchase.UnitPrice == null ? null : actualKiloPrice,
            Units = purchase.Units,
            Date = purchase.Date,
            Tax = purchase.Tax,
            TransportationFees = purchase.TransportationFees
        };

        await context.Purchases.AddAsync(purchaseEntity);
        context.Items.Update(item);
        context.Dealers.Update(dealer);
    }

    private async Task UpdatePurchase(PurchaseDto purchase)
    {
        var purchaseEntity =
            await context.Purchases.FindAsync(purchase.Id) ?? throw new Exception("Purchase not found");

        var newItem = await context.Items.FindAsync(purchase.ItemId) ?? throw new Exception("Item not found");

        var oldItem = await context.Items.FindAsync(purchaseEntity.ItemId) ?? throw new Exception("Item not found");

        var newDealer = await context.Dealers.FindAsync(purchase.DealerId) ?? throw new Exception("Dealer not found");

        var oldDealer = await context.Dealers.FindAsync(purchaseEntity.DealerId) ??
                        throw new Exception("Dealer not found");


        var newDealerItem = await context.DealerItems.FindAsync(new { DealerId = newDealer.Id, ItemId = newItem.Id }) ??
                            new DealerItem()
                            {
                                DealerId = purchase.DealerId,
                                ItemId = purchase.ItemId
                            };

        var oldDealerItem = await context.DealerItems.FindAsync(new
                                { DealerId = purchaseEntity.DealerId, ItemId = purchaseEntity.ItemId }) ??
                            throw new Exception("Old dealer item not found");

        decimal newActualKiloPrice = 0m, oldActualKiloPrice = 0m;
        if (purchase.UnitPrice.HasValue)
        {
            newActualKiloPrice = purchase.UnitPrice.Value +
                                 (purchase.Tax!.Value / purchase.Units);
        }

        if (purchaseEntity.UnitPrice.HasValue)
        {
            oldActualKiloPrice = purchaseEntity.UnitPrice.Value +
                                 (purchaseEntity.Tax!.Value / purchaseEntity.Units);
        }

        //TODO Check if required
        oldDealer.OutstandingBalance += purchaseEntity.TransportationFees ?? 0;
        newDealer.OutstandingBalance -= purchase.TransportationFees ?? 0;

        if (oldDealer.Type == PurchaseType.Direct)
        {
            var originalStock = oldItem.InHouseStock;
            oldItem.InHouseStock -= purchaseEntity.Units;

            var totalCostBefore = oldItem.AveragePrice * originalStock;
            var removedCost = oldActualKiloPrice * purchaseEntity.Units;

            var remainingStock = originalStock - purchaseEntity.Units;
            if (remainingStock > 0)
            {
                oldItem.AveragePrice = (totalCostBefore - removedCost) / remainingStock;
            }
            else
            {
                oldItem.AveragePrice = 0;
            }
        }
        else
        {
            oldDealerItem.CommissionedStock -= purchaseEntity.Units;
        }

        if (newDealer.Type == PurchaseType.Direct)
        {
            newItem.AveragePrice = (newItem.AveragePrice * newItem.InHouseStock + newActualKiloPrice * purchase.Units) /
                                   (newItem.InHouseStock + purchase.Units);

            newItem.InHouseStock += purchase.Units;
        }
        else
        {
            newDealerItem.CommissionedStock += purchase.Units;
        }

        purchaseEntity.DealerId = purchase.DealerId;
        purchaseEntity.ItemId = purchase.ItemId;
        purchaseEntity.Boxes = purchase.Boxes;
        purchaseEntity.UnitPrice = purchase.UnitPrice == null ? null : newActualKiloPrice;
        purchaseEntity.Units = purchase.Units;
        purchaseEntity.Date = purchase.Date;
        purchaseEntity.Tax = purchase.Tax;
        purchaseEntity.TransportationFees = purchase.TransportationFees;

        context.Purchases.Update(purchaseEntity);

        context.Items.Update(newItem);
        context.Dealers.Update(oldDealer);
        context.Dealers.Update(newDealer);
    }
}