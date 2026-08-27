using Tax_Radar_Domain.Enums;

namespace TaxRadar_Application.DTOs.Expenses;

public sealed record ExpenseDto(
    Guid Id,
    Guid UserId,
    string Description,
    decimal Amount,
    Currency Currency,
    DateOnly ExpenseDate,
    ExpenseCategory Category,
    DeductibilityStatus Deductibility,
    string? ReceiptImageUrl,
    ExpenseCategory? AiSuggestedCategory,
    DeductibilityStatus? AiSuggestedDeductibility,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
