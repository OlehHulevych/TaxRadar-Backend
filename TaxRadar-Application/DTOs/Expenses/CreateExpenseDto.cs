using Tax_Radar_Domain.Enums;

namespace TaxRadar_Application.DTOs.Expenses;

public sealed record CreateExpenseDto(
    Guid UserId,
    string Description,
    decimal Amount,
    Currency Currency,
    DateOnly ExpenseDate,
    ExpenseCategory Category,
    string? ReceiptImageUrl);
