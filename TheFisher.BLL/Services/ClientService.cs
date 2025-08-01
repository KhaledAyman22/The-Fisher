using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;
using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.Services;

public class ClientService(FisherDbContext context) : IClientService
{
    public async Task<List<ClientDropDownDto>> GetClientsForDropDown()
    {
        return await context.Clients.Select(c => new ClientDropDownDto(c.Id, c.Name)).ToListAsync();
    }

    public async Task<List<ClientDto>> GetClients()
    {
        return await context.Clients.Select(c => new ClientDto(c.Id, c.Name, c.OutstandingBalance)).ToListAsync();
    }

    public async Task AddClient(string name, decimal outstandingBalance)
    {
        var client = new Client()
        {
            Name = name,
            OutstandingBalance = outstandingBalance
        };

        context.Clients.Add(client);
        await context.SaveChangesAsync();
    }

    public async Task UpdateClient(int id, string name, decimal outstandingBalance)
    {
        var client = await context.Clients.FindAsync(id);

        if (client is null)
            throw new Exception("Client not found");

        client.Name = name;
        client.OutstandingBalance = outstandingBalance;

        await context.SaveChangesAsync();
    }

    public async Task<ClientDto> GetClient(int id)
    {
        var client = await context.Clients.FindAsync(id);

        if (client is null)
            throw new Exception("Client not found");

        return new ClientDto(client.Id, client.Name, client.OutstandingBalance);
    }

    public async Task DeleteClient(int id)
    {
        var client = await context.Clients.FindAsync(id);

        if (client is null)
            throw new Exception("Client not found");

        context.Remove(client);
        await context.SaveChangesAsync();
    }
}