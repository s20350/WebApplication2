using WebApplication2.models;

namespace WebApplication2.repositories;

public interface ITripRepository
{
    Task<IEnumerable<Trip>> GetAllAsync();
    Task<Trip> GetByIdAsync(int id);
    Task AddClientToTripAsync(Client_Trip clientTrip);
    Task<bool> TripExistsAsync(int id);
    Task<bool> ClientIsAssignedToTripAsync(int clientId, int tripId);
}