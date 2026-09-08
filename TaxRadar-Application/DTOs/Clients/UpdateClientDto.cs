using MediatR;

namespace TaxRadar_Application.DTOs.Clients;

public sealed record UpdateClientDto(
    Guid Id,
    string Name,
    string? Email,
    string? Ico,
    string? Dic,
    string? Street,
    string? City,
    string? PostalCode,
    string? Country):IRequest<ClientDto>;
