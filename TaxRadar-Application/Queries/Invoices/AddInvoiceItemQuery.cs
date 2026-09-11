using MediatR;
using TaxRadar_Application.DTOs.Invoices;

namespace TaxRadar_Application.Queries.Invoices;

public sealed record AddInvoiceItemQuery(Guid
        InvoiceId, string Description, decimal Quantity,
    decimal UnitPrice, decimal VatRatePercent):IRequest;