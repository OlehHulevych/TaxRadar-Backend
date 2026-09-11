using AutoMapper;
using MediatR;
using TaxRadar_Application.DTOs.Invoices;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Invoices;

namespace TaxRadar_Application.Commands.Invoices;

public class AddInvoiceItemCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper):IRequestHandler<AddInvoiceItemQuery, InvoiceDto>
{
    public async Task<InvoiceDto> Handle(AddInvoiceItemQuery request, CancellationToken cancellationToken)
    {
        
        
    }
}