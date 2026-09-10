using MediatR;
using Tax_Radar_Domain.Enums;
using TaxRadar_Application.DTOs.Expenses;

namespace TaxRadar_Application.Queries.Expenses;

public sealed record CreateExpenseQuery(
    Guid UserId,
    string Description,
    decimal Amount,
    Currency Currency,
    DateOnly ExpenseDate,
    ExpenseCategory Category,
    string? ReceiptImageUrl):IRequest<ExpenseDto>;
