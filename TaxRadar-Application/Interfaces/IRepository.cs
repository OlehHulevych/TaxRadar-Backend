using Tax_Radar_Domain.Common;

namespace TaxRadar_Application.Interfaces;

public interface IRepository<TEntity> where TEntity:BaseEntity
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);        
    Task SaveChangesAsync(CancellationToken cancellationToken);
}