namespace TaxRadar_Application.DTOs.Invoices;

public sealed record CreateInvoiceItemDto(string Description, decimal Quantity, decimal UnitPrice, decimal VatRatePercent);
