using FluentValidation;
using TaxRadar_Application.DTOs.Invoices;

namespace TaxRadar_Application.Validators.Invoices;

public sealed class UpdateInvoiceDtoValidator : AbstractValidator<UpdateInvoiceDto>
{
    public UpdateInvoiceDtoValidator()
    {
        RuleFor(x => x.InvoiceNumber)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.IssueDate)
            .NotEqual(default(DateOnly));

        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(x => x.IssueDate)
            .WithMessage("Due date cannot be before issue date.");
    }
}
