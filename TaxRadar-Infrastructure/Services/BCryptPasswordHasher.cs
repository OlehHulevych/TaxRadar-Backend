using TaxRadar_Application.Interfaces;

namespace TaxRadar_Infrastructure.Services;


public class BCryptPasswordHasher:IPasswordHasher
{
    public string Hash(string password)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        return passwordHash;
    }

    public bool Verify(string password, string hash)
    { 
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}