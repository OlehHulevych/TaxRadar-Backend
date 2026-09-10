using MediatR;
using TaxRadar_Application.DTOs.Expenses;

namespace TaxRadar_Application.Queries.Expenses;

public record GetExpenseByIdQuery(Guid Id):IRequest<ExpenseDto>{}