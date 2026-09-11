using MediatR;
using TaxRadar_Application.DTOs.Invoices;

namespace TaxRadar_Application.Queries.Invoices;

public sealed record UpdateInvoiceQuery(Guid Id,string InvoiceNumber, DateOnly IssueDate, DateOnly DueDate, string? Notes):IRequest<InvoiceDto>;
