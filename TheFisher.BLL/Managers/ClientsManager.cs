using System.ComponentModel.DataAnnotations;
using TheFisher.BLL.DTOs;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.Managers;

public class ClientsManager(FisherDbContext context)
{
    public void AddClient(ClientDto clientDto)
    {
        if (string.IsNullOrWhiteSpace(clientDto.Name))
        {
            throw new ValidationException("Client name cannot be empty.");
        }

        var client = new Client { Name = clientDto.Name, OutstandingBalance = 0 };
        context.Clients.Add(client);
        context.SaveChanges();
    }

    public List<ClientDto> GetClients()
    {
        return context.Clients
            .Select(c => new ClientDto
            {
                Id = c.Id,
                Name = c.Name,
                OutstandingBalance = c.OutstandingBalance
            })
            .ToList();
    }
}