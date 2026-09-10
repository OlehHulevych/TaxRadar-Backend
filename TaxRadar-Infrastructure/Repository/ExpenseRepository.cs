using Microsoft.EntityFrameworkCore;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;
using TaxRadar_Infrastructure.Persistance;

namespace TaxRadar_Infrastructure.Repository;

public class ExpenseRepository(ApplicationDbContext context):IRepository<Expense>
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

    public async Task<Expense> GetByUserId(Guid id, CancellationToken ct)
    {
        var expense = await context.Expenses.FirstOrDefaultAsync(e=>e.Id==id, ct);
        if (expense == null) throw new NotFoundException(nameof(Expense), id);
        return expense;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync();
    }
    
    
}