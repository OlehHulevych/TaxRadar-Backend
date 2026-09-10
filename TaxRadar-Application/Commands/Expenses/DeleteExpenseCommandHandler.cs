using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Expenses;

namespace TaxRadar_Application.Commands.Expenses;

public class DeleteExpenseCommandHandler(IExpenseRepository repository):IRequestHandler<DeleteExpenseQuery>
{
    public async Task Handle(DeleteExpenseQuery request, CancellationToken cancellationToken)
    {
        var expense = await repository.GetByIdAsync(request.Id,cancellationToken);
        if (expense == null) throw new NotFoundException(nameof(Expense), request.Id);
        await repository.DeleteAsync(expense, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}