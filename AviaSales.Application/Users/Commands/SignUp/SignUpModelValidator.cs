using AviaSales.Application.Users.Dto;
using FluentValidation;

namespace AviaSales.Application.Users.Commands.SignUp;

internal class SignUpModelValidator : AbstractValidator<SignUpModel>
{
    public SignUpModelValidator()
    {
        RuleFor(x => x.UserName)
            .NotNull().NotEmpty()
            .MinimumLength(3);

        RuleFor(x => x.Email)
            .NotNull().NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotNull().NotEmpty()
            .Equal(x => x.Password);
    }
}