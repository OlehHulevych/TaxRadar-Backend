using Microsoft.EntityFrameworkCore;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;
using TaxRadar_Infrastructure.Persistance;

namespace TaxRadar_Infrastructure.Repository;

public class ExpenseRepository(ApplicationDbContext context):IRepository<Expense>, IExpenseRepository
{
    public async Task<Expense?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var expense = await context.Expenses.FirstOrDefaultAsync(c=>c.Id==id,cancellationToken);
        if (expense == null) throw new NotFoundException(nameof(Expense), id);
        return expense;
    }

    public async Task AddAsync(Expense entity, CancellationToken cancellationToken)
    {
        await context.Expenses.AddAsync(entity, cancellationToken);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Expense entity, CancellationToken cancellationToken)
    {
        context.Expenses.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<IList<Expense>> GetByUserId(Guid id, CancellationToken ct)
    {
        var expenses = await context.Expenses.Where(e=>e.UserId==id).ToListAsync(ct);
        return expenses;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync();
    }
    
    
}