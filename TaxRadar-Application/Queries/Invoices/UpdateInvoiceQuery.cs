namespace TaxRadar_Application.Queries.Invoices;

public sealed record UpdateInvoiceQuery(string InvoiceNumber, DateOnly IssueDate, DateOnly DueDate, string? Notes);
