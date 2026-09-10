using MediatR;

namespace TaxRadar_Application.Queries.Clients;

public sealed record DeleteClientQuery(Guid Id):IRequest
{
    
}