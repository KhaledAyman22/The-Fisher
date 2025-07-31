using TheFisher.BLL.DTOs;

namespace TheFisher.BLL.IServices;

public interface IDealerService
{
    Task<List<DealerDropDownDto>> GetDealersForDropDown();
    Task AddDealer(string name, decimal outstandingBalance);
    Task UpdateDealer(int id, string name, decimal outstandingBalance);
    Task<DealerDto> GetDealer(int id);
    Task DeleteDealer(int id);
    Task<IEnumerable<DealerDto>> GetAllDealersAsync();
} 