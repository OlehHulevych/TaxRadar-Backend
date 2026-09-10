using FluentValidation;
using TaxRadar_Application.DTOs.Users;
using TaxRadar_Application.Queries.Users;

namespace TaxRadar_Application.Validators.Users;

public sealed class ChangeUserEmailDtoValidator : AbstractValidator<ChangeUserEmailQuery>
{
    public ChangeUserEmailDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
