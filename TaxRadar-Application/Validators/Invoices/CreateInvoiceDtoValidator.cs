using FluentValidation;
using TaxRadar_Application.DTOs.Invoices;
using TaxRadar_Application.Queries.Invoices;

namespace TaxRadar_Application.Validators.Invoices;

public sealed class CreateInvoiceDtoValidator : AbstractValidator<CreateInvoiceQuery>
{
    public CreateInvoiceDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.ClientId)
            .NotEmpty();

        RuleFor(x => x.InvoiceNumber)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Currency)
            .IsInEnum();

        RuleFor(x => x.IssueDate)
            .NotEqual(default(DateOnly));

        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(x => x.IssueDate)
            .WithMessage("Due date cannot be before issue date.");

        RuleForEach(x => x.Items)
            .SetValidator(new CreateInvoiceItemDtoValidator());
    }
}
