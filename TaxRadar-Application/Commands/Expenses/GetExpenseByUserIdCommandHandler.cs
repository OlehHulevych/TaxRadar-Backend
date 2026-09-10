using AutoMapper;
using MediatR;
using TaxRadar_Application.DTOs.Expenses;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Expenses;

namespace TaxRadar_Application.Commands.Expenses;

public class GetExpenseByUserIdCommandHandler(IExpenseRepository repository, IMapper mapper):IRequestHandler<GetExpenseByUserIdQuery, List<ExpenseDto>?>
{
    public async Task<List<ExpenseDto>?> Handle(GetExpenseByUserIdQuery request, CancellationToken cancellationToken)
    {
        var expenses = await repository.GetByUserId(request.UserId, cancellationToken);
        return expenses.Select(expense=>mapper.Map<ExpenseDto>(expense)).ToList();
    }
}