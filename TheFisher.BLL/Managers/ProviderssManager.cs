using System.ComponentModel.DataAnnotations;
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
}