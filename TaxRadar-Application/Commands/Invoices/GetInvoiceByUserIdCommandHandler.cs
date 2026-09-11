using AutoMapper;
using MediatR;
using TaxRadar_Application.DTOs.Invoices;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Invoices;

namespace TaxRadar_Application.Commands.Invoices;

public class GetInvoiceByUserIdCommandHandler(IInvoiceRepository repository, IMapper mapper):IRequestHandler<GetInvoiceByUserIdQuery, IList<InvoiceDto>>
{
    public async Task<IList<InvoiceDto>> Handle(GetInvoiceByUserIdQuery request, CancellationToken cancellationToken)
    {
        var invoices = await repository.GetByUserId(request.UserId,cancellationToken);
        return invoices.Select(invoice => mapper.Map<InvoiceDto>(invoice)).ToList();
    }
}