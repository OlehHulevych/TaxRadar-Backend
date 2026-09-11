using MediatR;
using TaxRadar_Application.DTOs.Invoices;

namespace TaxRadar_Application.Queries.Invoices;

public sealed record CreateInvoiceItemQuery(string Description, decimal Quantity, decimal UnitPrice, decimal VatRatePercent):IRequest<InvoiceDto>;
