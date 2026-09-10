using MediatR;
using TaxRadar_Application.DTOs.Clients;

namespace TaxRadar_Application.Queries.Clients;

public sealed record UpdateClientQuery(
    Guid Id,
    string Name,
    string? Email,
    string? Ico,
    string? Dic,
    string? Street,
    string? City,
    string? PostalCode,
    string? Country):IRequest<ClientDto>;
