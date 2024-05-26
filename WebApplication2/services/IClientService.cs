using WebApplication2.dto;

namespace WebApplication2.services;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetAllClientsAsync();
    Task<bool> DeleteClientAsync(int id);
    Task<bool> AddClientToTripAsync(int tripId, ClientDto clientDto);
}