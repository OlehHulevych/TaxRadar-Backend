using TaxRadar_Application.DTOs.Auth;

namespace TaxRadar_Application.Interfaces;

public interface IJwtTokenService
{
    AuthTokenResponseDto GenerateToken(Guid userId, string email);
}
