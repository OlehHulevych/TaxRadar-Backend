namespace TaxRadar_Application.DTOs.Invoices;

public sealed record UpdateInvoiceDto(string InvoiceNumber, DateOnly IssueDate, DateOnly DueDate, string? Notes);
