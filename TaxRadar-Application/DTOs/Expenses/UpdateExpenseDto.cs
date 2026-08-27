using Tax_Radar_Domain.Enums;

namespace TaxRadar_Application.DTOs.Expenses;

public sealed record UpdateExpenseDto(
    string Description,
    decimal Amount,
    Currency Currency,
    DateOnly ExpenseDate,
    ExpenseCategory Category);
