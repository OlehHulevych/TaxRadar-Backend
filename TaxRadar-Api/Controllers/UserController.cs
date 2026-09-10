using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaxRadar_Application.DTOs.Users;
using TaxRadar_Application.Queries.Users;

namespace TaxRadar_backned.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(ISender sender):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserQuery userQuery)
    {
        var clientDto = await sender.Send(userQuery);
        return Ok(clientDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserProfileQuery updateUserProfileQuery)
    {
        var clientDto = await sender.Send(updateUserProfileQuery);
        return Ok(clientDto);
    }

    [HttpPatch]
    public async Task<IActionResult> ChangeEmail([FromBody] ChangeUserEmailQuery changeUserEmailQuery)
    {
        var clientDto = await sender.Send(changeUserEmailQuery);
        return Ok(clientDto);
    }
}