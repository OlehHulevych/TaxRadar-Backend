namespace TaxRadar_Application.DTOs.Users;

public sealed record CreateUserDto(string Email, string FullName, string? Ico, string? Dic);
