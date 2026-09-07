using Tax_Radar_Domain.Entities;

namespace TaxRadar_Application.Interfaces;

public interface IClientRepository:IRepository<Client>
{
    Task<IReadOnlyList<Client>> GetByUserIdAsync(Guid userId, CancellationToken
        cancellationToken);
}