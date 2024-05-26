using Microsoft.EntityFrameworkCore;
using TripAPI.Data;
using WebApplication2.models;

namespace WebApplication2.repositories;

public class TripRepository : ITripRepository
{
    private readonly TripContext _context;

    public TripRepository(TripContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Trip>> GetAllAsync()
    {
        return await _context.Trips.OrderByDescending(t => t.DateFrom).ToListAsync();
    }

    public async Task<Trip> GetByIdAsync(int id)
    {
        return await _context.Trips.FindAsync(id);
    }

    public async Task AddClientToTripAsync(Client_Trip clientTrip)
    {
        await _context.Client_Trips.AddAsync(clientTrip);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> TripExistsAsync(int id)
    {
        return await _context.Trips.AnyAsync(t => t.IdTrip == id);
    }

    public async Task<bool> ClientIsAssignedToTripAsync(int clientId, int tripId)
    {
        return await _context.Client_Trips.AnyAsync(ct => ct.IdClient == clientId && ct.IdTrip == tripId);
    }
}