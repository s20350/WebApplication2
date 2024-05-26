using Microsoft.EntityFrameworkCore;
using TripAPI.Data;
using WebApplication2.models;

namespace WebApplication2.repositories;

public class ClientRepository : IClientRepository
{
    private readonly TripContext _context;

    public ClientRepository(TripContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> GetByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<Client> GetByPeselAsync(string pesel)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.Pesel == pesel);
    }

    public async Task AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Client client)
    {
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ClientExistsAsync(int id)
    {
        return await _context.Clients.AnyAsync(c => c.IdClient == id);
    }

    public async Task<bool> ClientHasTripsAsync(int id)
    {
        return await _context.Client_Trips.AnyAsync(ct => ct.IdClient == id);
    }
}