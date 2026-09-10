using AutoMapper;
using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Expenses;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Expenses;

namespace TaxRadar_Application.Commands.Expenses;

public class GetExpenseByIdCommandHandler(IRepository<Expense> repository, IMapper mapper):IRequestHandler<GetExpenseByIdQuery, ExpenseDto>
{
    public async Task<ExpenseDto> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var expense = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (expense == null) throw new NotFoundException(nameof(Expense), request.Id);
        return mapper.Map<ExpenseDto>(expense);
    }
}