using FluentValidation;

namespace AviaSales.Application.Users.Commands.SignIn;

internal class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        RuleFor(x => x.SignInModel)
            .NotNull()
            .SetValidator(new SignInModelValidator());
    }
}