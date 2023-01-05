using AviaSales.Application.Common.Models;
using AviaSales.Application.Users.Dto;
using MediatR;

namespace AviaSales.Application.Users.Commands.SignIn;

public class SignInCommand : IRequest<AuthResult>
{
    public SignInModel SignInModel { get; }

    public SignInCommand(SignInModel model)
    {
        SignInModel = model ?? throw new ArgumentNullException(nameof(model));
    }
}