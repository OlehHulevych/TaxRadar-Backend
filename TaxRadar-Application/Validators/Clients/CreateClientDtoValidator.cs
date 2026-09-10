using FluentValidation;
using TaxRadar_Application.DTOs.Clients;
using TaxRadar_Application.Queries.Clients;

namespace TaxRadar_Application.Validators.Clients;

public sealed class CreateClientDtoValidator : AbstractValidator<CreateClientQuery>
{
    public CreateClientDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.Ico)
            .Matches(CzechTaxIdPatterns.Ico)
            .When(x => !string.IsNullOrWhiteSpace(x.Ico))
            .WithMessage("ICO must be exactly 8 digits.");

        RuleFor(x => x.Dic)
            .Matches(CzechTaxIdPatterns.Dic)
            .When(x => !string.IsNullOrWhiteSpace(x.Dic))
            .WithMessage("DIC must be 'CZ' followed by 8-10 digits.");

        RuleFor(x => x)
            .Must(HaveCompleteOrNoAddress)
            .WithMessage("If any address field is provided, Street, City, PostalCode and Country are all required.");
    }

    private static bool HaveCompleteOrNoAddress(CreateClientQuery query)
    {
        var fields = new[] { query.Street, query.City, query.PostalCode, query.Country };
        var providedCount = fields.Count(f => !string.IsNullOrWhiteSpace(f));

        return providedCount == 0 || providedCount == fields.Length;
    }
}
