using Tax_Radar_Domain.Entities;

namespace TaxRadar_Application.Interfaces;

public interface IExpenseRepository:IRepository<Expense>
{
    public Task<IList<Expense>> GetByUserId(Guid id, CancellationToken ct);
}