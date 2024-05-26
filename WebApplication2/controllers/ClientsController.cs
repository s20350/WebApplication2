using Microsoft.AspNetCore.Mvc;
using WebApplication2.dto;
using WebApplication2.services;

namespace WebApplication2.controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpDelete("{idClient}")]
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        var result = await _clientService.DeleteClientAsync(idClient);
        if (!result)
        {
            return BadRequest("Client has assigned trips or does not exist.");
        }

        return NoContent();
    }

    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> AddClientToTrip(int idTrip, ClientDto clientDto)
    {
        var result = await _clientService.AddClientToTripAsync(idTrip, clientDto);
        if (!result)
        {
            return BadRequest("Client is already assigned to this trip or trip does not exist.");
        }

        return Ok();
    }
}