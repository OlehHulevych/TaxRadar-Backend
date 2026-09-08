using MediatR;

namespace TaxRadar_Application.DTOs.Clients;

public sealed record GetClientDetails(Guid Id):IRequest<ClientDto>;