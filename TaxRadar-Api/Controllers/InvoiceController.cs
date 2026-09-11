using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxRadar_Application.Queries.Invoices;

namespace TaxRadar_backned.Controllers;

[ApiController]
[Route("api/invoice")]
public class InvoiceController(ISender sender):ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetInvoiceByUserId([FromQuery] GetInvoiceByUserIdQuery query)
    {
        var invoice = await sender.Send(query);
        return Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceQuery query)
    {
        var invoice = await sender.Send(query);
        return Ok(invoice);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceQuery query)
    {
        var invoice = await sender.Send(query);
        return Ok(invoice);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddItemToInvoice([FromBody] AddInvoiceItemQuery query)
    {
        await sender.Send(query);
        return Ok(new { message = "Invoice item was added" });
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> RemoveItemFromInvoice([FromQuery] RemoveInvoiceItemQuery query)
    {
        await sender.Send(query);
        return Ok(new {messages = "Invoice item was deleted"});

    }
}