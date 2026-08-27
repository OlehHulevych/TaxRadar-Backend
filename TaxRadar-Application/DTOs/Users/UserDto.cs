namespace TaxRadar_Application.DTOs.Users;

public sealed record UserDto(
    Guid Id,
    string Email,
    string FullName,
    string? Ico,
    string? Dic,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
