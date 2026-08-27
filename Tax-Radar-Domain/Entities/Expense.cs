using Tax_Radar_Domain.Common;
using Tax_Radar_Domain.Enums;
using Tax_Radar_Domain.ValueObjects;

namespace Tax_Radar_Domain.Entities;

public class Expense : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Description { get; private set; }
    public Money Amount { get; private set; }
    public DateOnly ExpenseDate { get; private set; }
    public ExpenseCategory Category { get; private set; }
    public DeductibilityStatus Deductibility { get; private set; }
    public string? ReceiptImageUrl { get; private set; }

    // AI-derived suggestions only. They never overwrite Category/Deductibility directly —
    // a user must explicitly confirm them via ConfirmCategory/ConfirmDeductibility.
    public ExpenseCategory? AiSuggestedCategory { get; private set; }
    public DeductibilityStatus? AiSuggestedDeductibility { get; private set; }

    protected Expense()
    {
        Description = string.Empty;
        Amount = null!;
    }

    public Expense(
        Guid userId,
        string description,
        decimal amount,
        Currency currency,
        DateOnly expenseDate,
        ExpenseCategory category,
        string? receiptImageUrl = null)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required.", nameof(userId));

        ValidateFields(description, amount);

        UserId = userId;
        Description = description;
        Amount = new Money(amount, currency);
        ExpenseDate = expenseDate;
        Category = category;
        Deductibility = DeductibilityStatus.Unreviewed;
        ReceiptImageUrl = receiptImageUrl;
    }

    public void UpdateDetails(string description, decimal amount, Currency currency, DateOnly expenseDate, ExpenseCategory category)
    {
        ValidateFields(description, amount);

        Description = description;
        Amount = new Money(amount, currency);
        ExpenseDate = expenseDate;
        Category = category;
        MarkAsUpdated();
    }

    public void AttachReceipt(string receiptImageUrl)
    {
        if (string.IsNullOrWhiteSpace(receiptImageUrl))
            throw new ArgumentException("Receipt image URL is required.", nameof(receiptImageUrl));

        ReceiptImageUrl = receiptImageUrl;
        MarkAsUpdated();
    }

    public void SetAiSuggestion(ExpenseCategory suggestedCategory, DeductibilityStatus suggestedDeductibility)
    {
        AiSuggestedCategory = suggestedCategory;
        AiSuggestedDeductibility = suggestedDeductibility;
        MarkAsUpdated();
    }

    public void ConfirmCategory(ExpenseCategory category)
    {
        Category = category;
        MarkAsUpdated();
    }

    public void ConfirmDeductibility(DeductibilityStatus deductibility)
    {
        Deductibility = deductibility;
        MarkAsUpdated();
    }

    private static void ValidateFields(string description, decimal amount)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.", nameof(description));
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
    }
}
