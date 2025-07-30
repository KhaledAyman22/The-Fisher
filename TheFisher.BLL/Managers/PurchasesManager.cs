using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.DTOs;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.Managers;

public class PurchasesManager(FisherDbContext context)
{
    public void AddPurchase(CreatePurchaseDto purchaseDto)
    {
        if (purchaseDto.Units <= 0 || purchaseDto.UnitPrice <= 0)
        {
            throw new ValidationException("Units and Unit Price must be positive.");
        }

        var purchase = new Purchase
        {
            ProviderId = purchaseDto.ProviderId,
            ItemId = purchaseDto.ItemId,
            Units = purchaseDto.Units,
            UnitPrice = purchaseDto.UnitPrice,
            Date = DateTime.UtcNow
        };
        context.Purchases.Add(purchase);
        context.SaveChanges();
    }

    public List<PurchaseDto> GetTodaysPurchases()
    {
        var purchases = context.Purchases
            .Include(p => p.Provider)
            .Include(p => p.Item)
            .Where(p => p.Date.Date == DateTime.UtcNow.Date)
            .ToList();

        return purchases.Select(p => new PurchaseDto
        {
            Id = p.Id,
            ProviderName = p.Provider?.Name ?? throw new Exception("Unknown Provider"),
            ItemName = p.Item?.Name ?? throw new Exception("Unknown Item"),
            Units = p.Units,
            UnitPrice = p.UnitPrice,
            Total = p.Units * p.UnitPrice,
            Date = p.Date
        }).ToList();
    }
}