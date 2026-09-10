using MediatR;
using TaxRadar_Application.DTOs.Expenses;

namespace TaxRadar_Application.Queries.Expenses;

public record GetExpenseByUserIdQuery(Guid UserId):IRequest<List<ExpenseDto>>{}