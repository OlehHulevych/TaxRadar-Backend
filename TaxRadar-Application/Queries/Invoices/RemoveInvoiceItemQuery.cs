using MediatR;
using TaxRadar_Application.DTOs.Invoices;

namespace TaxRadar_Application.Queries.Invoices;

public sealed record RemoveInvoiceItemQuery(Guid
    InvoiceId, Guid ItemId):IRequest;