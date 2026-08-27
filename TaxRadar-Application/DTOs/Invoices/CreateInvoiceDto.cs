using Tax_Radar_Domain.Enums;

namespace TaxRadar_Application.DTOs.Invoices;

public sealed record CreateInvoiceDto(
    Guid UserId,
    Guid ClientId,
    string InvoiceNumber,
    DateOnly IssueDate,
    DateOnly DueDate,
    Currency Currency,
    string? Notes,
    IReadOnlyList<CreateInvoiceItemDto> Items);
