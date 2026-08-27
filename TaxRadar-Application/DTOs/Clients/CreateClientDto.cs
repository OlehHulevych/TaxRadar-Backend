namespace TaxRadar_Application.DTOs.Clients;

public sealed record CreateClientDto(
    Guid UserId,
    string Name,
    string? Email,
    string? Ico,
    string? Dic,
    string? Street,
    string? City,
    string? PostalCode,
    string? Country);
