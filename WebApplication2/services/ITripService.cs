using WebApplication2.dto;

namespace WebApplication2.services;

public interface ITripService
{
    Task<IEnumerable<TripDto>> GetAllTripsAsync();
}