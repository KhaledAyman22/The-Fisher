using System.ComponentModel.DataAnnotations;
using TheFisher.BLL.DTOs;
using TheFisher.DAL;
using TheFisher.DAL.Entities;

namespace TheFisher.BLL.Managers;

public class ItemsManager(FisherDbContext context)
{
    public void AddItem(ItemDto itemDto)
    {
        if (string.IsNullOrWhiteSpace(itemDto.Name))
        {
            throw new ValidationException("Item name cannot be empty.");
        }

        var item = new Item { Name = itemDto.Name };
        context.Items.Add(item);
        context.SaveChanges();
    }

    public List<ItemDto> GetItems()
    {
        return context.Items
            .Select(i => new ItemDto { Id = i.Id, Name = i.Name })
            .ToList();
    }
}