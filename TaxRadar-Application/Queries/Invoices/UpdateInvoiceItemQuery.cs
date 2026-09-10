namespace TaxRadar_Application.Queries.Invoices;

public sealed record UpdateInvoiceItemQuery(string Description, decimal Quantity, decimal UnitPrice, decimal VatRatePercent);
