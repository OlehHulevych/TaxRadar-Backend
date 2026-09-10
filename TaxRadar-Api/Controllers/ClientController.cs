using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TaxRadar_Application.Commands.Clients;
using TaxRadar_Application.DTOs.Clients;
using TaxRadar_Application.Queries.Clients;

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
    public async Task<IActionResult> CreateClient([FromBody] CreateClientQuery command )
    {
        var client = await _sender.Send(command);
        return Ok(client);
    }

    [HttpGet]
    public async Task<IActionResult> GetClient([FromQuery] GetClientDetailsQuery command)
    {
        var clientDto = await _sender.Send(command);
        return Ok(clientDto);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateClient([FromBody] UpdateClientQuery command)
    {
        var clientDto = await _sender.Send(command);
        return Ok(clientDto);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteClient([FromQuery] DeleteClientQuery command)
    {
        await _sender.Send(command);
        return Ok(new {message = $"Client {command.Id} was deleted"});

    }
    
    
    
}