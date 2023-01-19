using FluentValidation;

namespace AviaSales.Application.Users.Commands.SignUp;

internal class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(x => x.SignUpModel)
            .NotNull()
            .SetValidator(new SignUpModelValidator());
    }
}