namespace TaxRadar_Application.DTOs.Invoices;

public sealed record InvoiceItemDto(
    Guid Id,
    Guid InvoiceId,
    string Description,
    decimal Quantity,
    decimal UnitPrice,
    decimal VatRatePercent,
    decimal NetAmount,
    decimal VatAmount,
    decimal GrossAmount);
