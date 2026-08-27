using Tax_Radar_Domain.Enums;

namespace TaxRadar_Application.DTOs.Invoices;

public sealed record InvoiceDto(
    Guid Id,
    Guid UserId,
    Guid ClientId,
    string InvoiceNumber,
    DateOnly IssueDate,
    DateOnly DueDate,
    Currency Currency,
    InvoiceStatus Status,
    string? Notes,
    IReadOnlyList<InvoiceItemDto> Items,
    decimal TotalGrossAmount,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
