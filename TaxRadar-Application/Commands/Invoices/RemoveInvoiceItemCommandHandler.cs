using MediatR;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Invoices;

namespace TaxRadar_Application.Commands.Invoices;

public class RemoveInvoiceItemCommandHandler(IInvoiceRepository repository):IRequestHandler<RemoveInvoiceItemQuery>
{
    public async Task Handle(RemoveInvoiceItemQuery request, CancellationToken cancellationToken)
    {
        await repository.RemoveItemFromInvoice(request.InvoiceId, request.ItemId, cancellationToken);
    }
}