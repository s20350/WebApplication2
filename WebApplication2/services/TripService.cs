using WebApplication2.dto;
using WebApplication2.repositories;

namespace WebApplication2.services;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<IEnumerable<TripDto>> GetAllTripsAsync()
    {
        var trips = await _tripRepository.GetAllAsync();
        return trips.Select(t => new TripDto
        {
            IdTrip = t.IdTrip,
            Name = t.Name,
            Description = t.Description,
            DateFrom = t.DateFrom,
            DateTo = t.DateTo,
            MaxPeople = t.MaxPeople
        });
    }
}