using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.DTOs;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.Managers;

public class ProvidersManager(FisherDbContext context)
{
    public void AddProvider(ProviderDto providerDto)
    {
        if (string.IsNullOrWhiteSpace(providerDto.Name))
        {
            throw new ValidationException("Provider name cannot be empty.");
        }

        var provider = new Provider { Name = providerDto.Name };
        context.Providers.Add(provider);
        context.SaveChanges();
    }

    public List<ProviderDto> GetProviders()
    {
        return context.Providers
            .Select(p => new ProviderDto { Id = p.Id, Name = p.Name })
            .ToList();
    }

    public List<PurchaseDto> GetPurchasesByProvider(int providerId)
    {
        var purchases = context.Purchases
            .Where(p => p.ProviderId == providerId)
            .Include(p => p.Provider)
            .Include(p => p.Item)
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