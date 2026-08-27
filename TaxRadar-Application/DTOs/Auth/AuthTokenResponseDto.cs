namespace TaxRadar_Application.DTOs.Auth;

public sealed record AuthTokenResponseDto(string AccessToken, DateTime ExpiresAtUtc);
