using FluentValidation;
using TaxRadar_Application.DTOs.Invoices;
using TaxRadar_Application.Queries.Invoices;

namespace TaxRadar_Application.Validators.Invoices;

public sealed class UpdateInvoiceItemDtoValidator : AbstractValidator<UpdateInvoiceItemQuery>
{
    public UpdateInvoiceItemDtoValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Quantity)
            .GreaterThan(0);

        RuleFor(x => x.UnitPrice)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.VatRatePercent)
            .GreaterThanOrEqualTo(0);
    }
}
