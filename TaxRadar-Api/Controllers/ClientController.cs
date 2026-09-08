using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
    public async Task<IActionResult> CreateClient([FromBody] CreateClientDto command )
    {
        var client = await _sender.Send(command);
        return Ok(client);
    }

    [HttpGet]
    public async Task<IActionResult> GetClient([FromQuery] GetClientDetails command)
    {
        var clientDto = await _sender.Send(command);
        return Ok(clientDto);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateClient([FromBody] UpdateClientDto command)
    {
        var clientDto = await _sender.Send(command);
        return Ok(clientDto);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteClient([FromQuery] DeleteClientDto command)
    {
        await _sender.Send(command);
        return Ok(new {message = $"Client {command.Id} was deleted"});

    }
    
    
    
}