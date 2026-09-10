using FluentValidation;
using TaxRadar_Application.DTOs.Auth;
using TaxRadar_Application.Queries.Auth;

namespace TaxRadar_Application.Validators.Auth;

public sealed class RegisterDtoValidator : AbstractValidator<RegisterQuery>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.");
    }
}
