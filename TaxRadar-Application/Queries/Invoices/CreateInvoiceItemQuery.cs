namespace TaxRadar_Application.Queries.Invoices;

public sealed record CreateInvoiceItemQuery(string Description, decimal Quantity, decimal UnitPrice, decimal VatRatePercent);
