using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaxRadar_Application.DTOs.Users;

namespace TaxRadar_backned.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(ISender sender):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
        var clientDto = await sender.Send(userDto);
        return Ok(clientDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserProfileDto updateUserProfileDto)
    {
        var clientDto = await sender.Send(updateUserProfileDto);
        return Ok(clientDto);
    }

    [HttpPatch]
    public async Task<IActionResult> ChangeEmail([FromBody] ChangeUserEmailDto changeUserEmailDto)
    {
        var clientDto = await sender.Send(changeUserEmailDto);
        return Ok(clientDto);
    }
}