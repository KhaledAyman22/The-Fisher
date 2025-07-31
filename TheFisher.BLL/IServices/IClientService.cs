using TheFisher.BLL.DTOs;

namespace TheFisher.BLL.IServices;

public interface IClientService
{
    Task <List<ClientDropDownDto>> GetClientsForDropDown();
    Task AddClient(string name, decimal outstandingBalance);
    Task UpdateClient(int id, string name, decimal outstandingBalance);
    Task<ClientDto> GetClient(int id);
    Task DeleteClient(int id);

}