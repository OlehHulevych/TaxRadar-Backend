namespace TaxRadar_Application.DTOs.Clients;

public sealed record ClientDto(
    Guid Id,
    Guid UserId,
    string Name,
    string? Email,
    string? Ico,
    string? Dic,
    string? Street,
    string? City,
    string? PostalCode,
    string? Country,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
