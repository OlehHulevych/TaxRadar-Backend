using MediatR;
using TaxRadar_Application.DTOs.Clients;

namespace TaxRadar_Application.Queries.Clients;

public sealed record GetClientDetailsQuery(Guid Id):IRequest<ClientDto>;