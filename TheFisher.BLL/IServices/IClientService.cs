using TheFisher.BLL.Dtos;

namespace TheFisher.BLL.IServices;

public interface IClientService
{
    Task <List<ClientDropDownDto>> GetClientsForDropDown();
    Task <List<ClientDto>> GetClients();

    Task AddClient(string name, decimal outstandingBalance);
    Task UpdateClient(int id, string name, decimal outstandingBalance);
    Task<ClientDto> GetClient(int id);
    Task DeleteClient(int id);

}