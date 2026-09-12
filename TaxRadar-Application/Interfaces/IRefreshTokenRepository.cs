using Tax_Radar_Domain.Entities;

namespace TaxRadar_Application.Interfaces;

public interface IRefreshTokenRepository:IRepository<RefreshToken>
{
    public Task<RefreshToken?> GetByUserId(Guid id, CancellationToken cancellationToken);
}