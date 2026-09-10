using FluentValidation;
using TaxRadar_Application.DTOs.Users;
using TaxRadar_Application.Queries.Users;

namespace TaxRadar_Application.Validators.Users;

public sealed class UpdateUserProfileDtoValidator : AbstractValidator<UpdateUserProfileQuery>
{
    public UpdateUserProfileDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Ico)
            .Matches(CzechTaxIdPatterns.Ico)
            .When(x => !string.IsNullOrWhiteSpace(x.Ico))
            .WithMessage("ICO must be exactly 8 digits.");

        RuleFor(x => x.Dic)
            .Matches(CzechTaxIdPatterns.Dic)
            .When(x => !string.IsNullOrWhiteSpace(x.Dic))
            .WithMessage("DIC must be 'CZ' followed by 8-10 digits.");
    }
}
