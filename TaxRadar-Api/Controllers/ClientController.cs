using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxRadar_Application.Commands.Clients;
using TaxRadar_Application.DTOs.Clients;

namespace TaxRadar_backned.Controllers;
[Route("api/client")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ISender _sender;

    public ClientController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient(CreateClientDto command )
    {
        var client = await _sender.Send(command);
        return Ok(client);
    }
    
    
}