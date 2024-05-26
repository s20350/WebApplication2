using WebApplication2.models;

namespace WebApplication2.repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<Client> GetByIdAsync(int id);
    Task<Client> GetByPeselAsync(string pesel);
    Task AddAsync(Client client);
    Task RemoveAsync(Client client);
    Task<bool> ClientExistsAsync(int id);
    Task<bool> ClientHasTripsAsync(int id);
}