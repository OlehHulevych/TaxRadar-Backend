using FluentValidation;
using TaxRadar_Application.DTOs.Auth;
using TaxRadar_Application.Queries.Auth;

namespace TaxRadar_Application.Validators.Auth;

public sealed class LoginDtoValidator : AbstractValidator<LoginQuery>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}
