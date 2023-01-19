using AviaSales.Application.Common.Models;
using AviaSales.Application.Users.Dto;
using MediatR;

namespace AviaSales.Application.Users.Commands.SignUp;

public class SignUpCommand : IRequest<AuthResult>
{
    public SignUpModel SignUpModel { get; }

    public SignUpCommand(SignUpModel model)
    {
        SignUpModel = model ?? throw new ArgumentNullException(nameof(model));
    }
}