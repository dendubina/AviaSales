using AviaSales.Application.Common.Models.Users;
using FluentValidation;

namespace AviaSales.Application.Users.Commands.SignIn;

internal class SignInModelValidator : AbstractValidator<SignInModel>
{
    public SignInModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotNull().NotEmpty();
    }
}