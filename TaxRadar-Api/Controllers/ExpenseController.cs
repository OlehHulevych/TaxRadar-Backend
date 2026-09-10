using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxRadar_Application.Queries.Expenses;

namespace TaxRadar_backned.Controllers;

[ApiController]
[Route("api/expense")]
public class ExpenseController(ISender sender):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseQuery query)
    {
        var expense = await sender.Send(query);
        return Ok(expense);
    }

    [HttpGet]
    public async Task<IActionResult> GetExpenseByUserId([FromQuery] GetExpenseByUserIdQuery query)
    {
        var expense = await sender.Send(query);
        return Ok(expense);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateExpense([FromBody] UpdateExpenseQuery query)
    {
        var expense = await sender.Send(query);
        return Ok(expense);

    }

    [HttpDelete]
    public async Task<IActionResult> DeleteExpense([FromQuery] DeleteExpenseQuery query)
    {
        await sender.Send(query);
        return Ok(new {message = $"The expense {query.Id} was deleted"});
    }
}