using MediatR;
using TaxRadar_Application.DTOs.Invoices;

namespace TaxRadar_Application.Queries.Invoices;

public record GetInvoiceByUserIdQuery(Guid UserId):IRequest<IList<InvoiceDto>>;