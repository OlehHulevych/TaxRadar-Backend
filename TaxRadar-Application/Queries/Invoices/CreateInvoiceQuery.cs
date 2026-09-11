using MediatR;
using Tax_Radar_Domain.Enums;
using TaxRadar_Application.DTOs.Invoices;

namespace TaxRadar_Application.Queries.Invoices;

public sealed record CreateInvoiceQuery(
    Guid UserId,
    Guid ClientId,
    string InvoiceNumber,
    DateOnly IssueDate,
    DateOnly DueDate,
    Currency Currency,
    string? Notes,
    IReadOnlyList<CreateInvoiceItemQuery> Items):IRequest<InvoiceDto>;
