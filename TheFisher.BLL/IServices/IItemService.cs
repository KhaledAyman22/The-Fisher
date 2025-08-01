using TheFisher.BLL.Dtos;

namespace TheFisher.BLL.IServices;

public interface IItemService
{
    Task<List<ItemDropDownDto>> GetItemsForDropDown();
    Task AddItem(string name);
    Task UpdateItem(int id, string name);
    Task<ItemDto> GetItem(int id);
    Task DeleteItem(int id);
    Task<IEnumerable<ItemDto>> GetAllItemsAsync();
} 