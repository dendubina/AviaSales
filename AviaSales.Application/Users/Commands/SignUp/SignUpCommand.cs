using AviaSales.Application.Common.Models.Users;
using MediatR;

namespace AviaSales.Application.Users.Commands.SignUp;

public class SignUpCommand : IRequest<Result>
{
    public SignUpModel SignUpModel { get; }

    public SignUpCommand(SignUpModel model)
    {
        SignUpModel = model ?? throw new ArgumentNullException(nameof(model));
    }
}