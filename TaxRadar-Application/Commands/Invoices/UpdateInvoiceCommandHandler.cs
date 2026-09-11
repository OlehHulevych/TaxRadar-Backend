using AutoMapper;
using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Invoices;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Invoices;

namespace TaxRadar_Application.Commands.Invoices;

public class UpdateInvoiceCommandHandler(IInvoiceRepository repository, IMapper mapper):IRequestHandler<UpdateInvoiceQuery,InvoiceDto>
{
    public async Task<InvoiceDto> Handle(UpdateInvoiceQuery request, CancellationToken cancellationToken)
    {
        var invoiceForUpdate = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (invoiceForUpdate == null) throw new NotFoundException(nameof(Invoice), request.Id);
        invoiceForUpdate.UpdateDetails(request.InvoiceNumber,request.IssueDate,request.DueDate,request.Notes);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<InvoiceDto>(invoiceForUpdate);
    }
}