using Microsoft.EntityFrameworkCore;
using TheFisher.BLL.Dtos;
using TheFisher.BLL.IServices;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.Services;

public class ItemService : IItemService
{
    private readonly FisherDbContext _context;

    public ItemService(FisherDbContext context)
    {
        _context = context;
    }

    public async Task<List<ItemDropDownDto>> GetItemsForDropDown()
    {
        return await _context.Items.Select(i => new ItemDropDownDto(i.Id, i.Name)).ToListAsync();
    }

    public async Task AddItem(string name)
    {
        var item = new Item()
        {
            Name = name,
            Stock = 0,
            CommissionedStock = 0,
            AvgPricePerKg = 0
        };

        _context.Items.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItem(int id, string name)
    {
        var item = await _context.Items.FindAsync(id);

        if (item is null)
            throw new Exception("Item not found");

        item.Name = name;
        await _context.SaveChangesAsync();
    }

    public async Task<ItemDto> GetItem(int id)
    {
        var item = await _context.Items.FindAsync(id);

        if (item is null)
            throw new Exception("Item not found");

        return new ItemDto(item.Id, item.Name, item.Stock, item.CommissionedStock, item.AvgPricePerKg);
    }

    public async Task DeleteItem(int id)
    {
        var item = await _context.Items.FindAsync(id);

        if (item is null)
            throw new Exception("Item not found");

        _context.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
    {
        return await _context.Items.Select(i => new ItemDto(i.Id, i.Name, i.Stock, i.CommissionedStock, i.AvgPricePerKg)).ToListAsync();
    }
} 