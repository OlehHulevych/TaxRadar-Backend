using FluentValidation;
using TaxRadar_Application.DTOs.Users;

namespace TaxRadar_Application.Validators.Users;

public sealed class ChangeUserEmailDtoValidator : AbstractValidator<ChangeUserEmailDto>
{
    public ChangeUserEmailDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
