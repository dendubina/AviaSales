using AviaSales.Application.Common.Attributes;
using MediatR;
using System.Reflection;
using AviaSales.Application.Common.Interfaces;

namespace AviaSales.Application.Common.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    readonly ICurrentUserService _currentUserService;

    public AuthorizationBehavior(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>().ToArray();

        if (authAttributes.Any())
        {
            var userId = await _currentUserService.GetCurrentUserId();

            if (string.IsNullOrWhiteSpace(userId) || await _currentUserService.IsAuthorized() == false)
            {
                throw new UnauthorizedAccessException("Not authorized access");
            }
        }

        return await next();
    }
}