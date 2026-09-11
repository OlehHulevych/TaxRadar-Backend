using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaxRadar_Application.DTOs.Auth;
using TaxRadar_Application.Interfaces;

namespace TaxRadar_Infrastructure.Services;

public class JwtTokenService(IConfiguration config):IJwtTokenService
{
    public AuthTokenResponseDto GenerateToken(Guid userId, string email)
    {
        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Email, email)
            
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Secret"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expirity = DateTime.Now.AddMinutes(config.GetValue<int>("Jwt:ExpiryMinutes", 60));
        var token = new JwtSecurityToken(
            issuer:config["Jwt:Issuer"],
            audience:config["Jwt:Audience"],
            claims:claims,
            expires:expirity,
            signingCredentials:creds
            );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return new AuthTokenResponseDto(tokenString,expirity);




    }
}