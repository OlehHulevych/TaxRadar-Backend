using AutoMapper;
using MediatR;
using TaxRadar_Application.DTOs.Invoices;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Invoices;

namespace TaxRadar_Application.Commands.Invoices;

public class AddInvoiceItemCommandHandler(IInvoiceRepository invoiceRepository):IRequestHandler<AddInvoiceItemQuery>
{
    public async Task Handle(AddInvoiceItemQuery request, CancellationToken cancellationToken)
    {
        var itemQuery = new CreateInvoiceItemQuery(request.Description,request.Quantity,request.UnitPrice,request.VatRatePercent);
        await invoiceRepository.AddItemToInvoice(request.InvoiceId, itemQuery, cancellationToken);
    }
}