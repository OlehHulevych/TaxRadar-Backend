using Tax_Radar_Domain.Common;

namespace Tax_Radar_Domain.Entities;

public class RefreshToken:BaseEntity
{
    public Guid UserId { get; private set; }
    public string TokenHash { get; private set; }
    public DateTimeOffset? RevokedAt { get; private set; }
    public DateTimeOffset ExpiresAt { get; private set; }

    protected RefreshToken()
    {
        TokenHash = String.Empty;
    }

    public RefreshToken(Guid userId, string tokenHash, DateTimeOffset expiresAt)
    {
        if (userId == Guid.Empty) throw new ArgumentException("UserId is required.", nameof(userId));
        if (string.IsNullOrEmpty(tokenHash)) throw new ArgumentException("TokenHash is required.", nameof(tokenHash));

        UserId = userId;
        TokenHash = tokenHash;
        ExpiresAt = expiresAt;
    }

    public void Revoke()
    {
        if (RevokedAt is not null) return;
        RevokedAt = DateTimeOffset.UtcNow;
    }
    

}