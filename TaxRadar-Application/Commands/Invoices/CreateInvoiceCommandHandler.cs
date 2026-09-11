using AutoMapper;
using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Invoices;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Invoices;

namespace TaxRadar_Application.Commands.Invoices;

public class CreateInvoiceCommandHandler(IInvoiceRepository repository, IMapper mapper):IRequestHandler<CreateInvoiceQuery, InvoiceDto> 
{
    public async Task<InvoiceDto> Handle(CreateInvoiceQuery request, CancellationToken cancellationToken)
    {
        var newInvoice = new Invoice(request.UserId,request.ClientId,request.InvoiceNumber,request.IssueDate,request.DueDate,request.Currency,request.Notes);
        if (request.Items.Any())
        {
            foreach (var item in request.Items )
            {
                newInvoice.AddItem(item.Description,item.Quantity,item.UnitPrice,item.VatRatePercent);
            }
        }

        await repository.AddAsync(newInvoice, cancellationToken);

        return mapper.Map<InvoiceDto>(newInvoice);
    }
}