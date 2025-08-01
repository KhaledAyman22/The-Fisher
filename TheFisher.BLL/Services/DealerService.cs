using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;
using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.Services;

public class DealerService : IDealerService
{
    private readonly FisherDbContext _context;

    public DealerService(FisherDbContext context)
    {
        _context = context;
    }

    public async Task<List<DealerDropDownDto>> GetDealersForDropDown()
    {
        return await _context.Dealers.Select(d => new DealerDropDownDto(d.Id, d.Name)).ToListAsync();
    }

    public async Task AddDealer(string name, decimal outstandingBalance)
    {
        var dealer = new Dealer()
        {
            Name = name,
            OutstandingBalance = outstandingBalance
        };

        _context.Dealers.Add(dealer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDealer(int id, string name, decimal outstandingBalance)
    {
        var dealer = await _context.Dealers.FindAsync(id);

        if (dealer is null)
            throw new Exception("Dealer not found");

        dealer.Name = name;
        dealer.OutstandingBalance = outstandingBalance;

        await _context.SaveChangesAsync();
    }

    public async Task<DealerDto> GetDealer(int id)
    {
        var dealer = await _context.Dealers.FindAsync(id);

        if (dealer is null)
            throw new Exception("Dealer not found");

        return new DealerDto(dealer.Id, dealer.Name, dealer.OutstandingBalance);
    }

    public async Task DeleteDealer(int id)
    {
        var dealer = await _context.Dealers.FindAsync(id);

        if (dealer is null)
            throw new Exception("Dealer not found");

        _context.Remove(dealer);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<DealerDto>> GetAllDealersAsync()
    {
        return await _context.Dealers.Select(d => new DealerDto(d.Id, d.Name, d.OutstandingBalance)).ToListAsync();
    }
} 