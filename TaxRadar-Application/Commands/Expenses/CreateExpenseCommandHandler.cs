using AutoMapper;
using MediatR;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Expenses;
using TaxRadar_Application.Interfaces;
using TaxRadar_Application.Queries.Expenses;

namespace TaxRadar_Application.Commands.Expenses;

public class CreateExpenseCommandHandler(IRepository<Expense> repository, IMapper mapper):IRequestHandler<CreateExpenseQuery, ExpenseDto>
{
    public async Task<ExpenseDto> Handle(CreateExpenseQuery request, CancellationToken cancellationToken)
    {
        var newExpense = new Expense(request.UserId,request.Description, request.Amount,request.Currency,request.ExpenseDate,request.Category, request.ReceiptImageUrl);
        await repository.AddAsync(newExpense,cancellationToken);
        return mapper.Map<ExpenseDto>(newExpense);

    }
}