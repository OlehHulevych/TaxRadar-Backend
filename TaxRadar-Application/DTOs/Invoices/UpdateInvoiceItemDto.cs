namespace TaxRadar_Application.DTOs.Invoices;

public sealed record UpdateInvoiceItemDto(string Description, decimal Quantity, decimal UnitPrice, decimal VatRatePercent);
