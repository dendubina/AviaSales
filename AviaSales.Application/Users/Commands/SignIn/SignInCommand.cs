using AviaSales.Application.Common.Models.Users;
using MediatR;

namespace AviaSales.Application.Users.Commands.SignIn;

public class SignInCommand : IRequest<Result>
{
    public SignInModel SignInModel { get; init; }

    public SignInCommand(SignInModel model)
    {
        SignInModel = model ?? throw new ArgumentNullException(nameof(model));
    }
}