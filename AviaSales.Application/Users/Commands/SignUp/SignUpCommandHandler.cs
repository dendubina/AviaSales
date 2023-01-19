using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Common.Models;
using MediatR;

namespace AviaSales.Application.Users.Commands.SignUp;

internal class SignUpCommandHandler : IRequestHandler<SignUpCommand, AuthResult>
{
    readonly IIdentityService _identityService;

    public SignUpCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<AuthResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
        => await _identityService.SignUpAsync(request.SignUpModel);
}