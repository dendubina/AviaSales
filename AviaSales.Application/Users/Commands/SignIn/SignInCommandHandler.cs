using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Common.Models;
using MediatR;

namespace AviaSales.Application.Users.Commands.SignIn;

internal class SignInCommandHandler : IRequestHandler<SignInCommand, AuthResult>
{
    private readonly IIdentityService _identityService;

    public SignInCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<AuthResult> Handle(SignInCommand request, CancellationToken cancellationToken)
        => await _identityService.SignInAsync(request.SignInModel);
}