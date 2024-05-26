using WebApplication2.dto;
using WebApplication2.models;
using WebApplication2.repositories;

namespace WebApplication2.services;

public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ITripRepository _tripRepository;

        public ClientService(IClientRepository clientRepository, ITripRepository tripRepository)
        {
            _clientRepository = clientRepository;
            _tripRepository = tripRepository;
        }

        public async Task<IEnumerable<ClientDto>> GetAllClientsAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return clients.Select(c => new ClientDto
            {
                IdClient = c.IdClient,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Telephone = c.Telephone,
                Pesel = c.Pesel
            });
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null || await _clientRepository.ClientHasTripsAsync(id))
            {
                return false;
            }

            await _clientRepository.RemoveAsync(client);
            return true;
        }

        public async Task<bool> AddClientToTripAsync(int tripId, ClientDto clientDto)
        {
            if (!await _tripRepository.TripExistsAsync(tripId))
            {
                return false;
            }

            var client = await _clientRepository.GetByPeselAsync(clientDto.Pesel);
            if (client == null)
            {
                client = new Client
                {
                    FirstName = clientDto.FirstName,
                    LastName = clientDto.LastName,
                    Email = clientDto.Email,
                    Telephone = clientDto.Telephone,
                    Pesel = clientDto.Pesel
                };
                await _clientRepository.AddAsync(client);
            }

            if (await _tripRepository.ClientIsAssignedToTripAsync(client.IdClient, tripId))
            {
                return false;
            }

            var clientTrip = new Client_Trip
            {
                IdClient = client.IdClient,
                IdTrip = tripId,
                RegisteredAt = DateTime.Now
            };

            await _tripRepository.AddClientToTripAsync(clientTrip);
            return true;
        }
    }