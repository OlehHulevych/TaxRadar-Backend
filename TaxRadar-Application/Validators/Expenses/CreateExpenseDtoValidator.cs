using FluentValidation;
using TaxRadar_Application.DTOs.Expenses;
using TaxRadar_Application.Queries.Expenses;

namespace TaxRadar_Application.Validators.Expenses;

public sealed class CreateExpenseDtoValidator : AbstractValidator<CreateExpenseQuery>
{
    public CreateExpenseDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Amount)
            .GreaterThan(0);

        RuleFor(x => x.Currency)
            .IsInEnum();

        RuleFor(x => x.Category)
            .IsInEnum();

        RuleFor(x => x.ExpenseDate)
            .NotEqual(default(DateOnly));
    }
}
