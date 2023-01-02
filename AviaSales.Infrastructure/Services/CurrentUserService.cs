using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AviaSales.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace AviaSales.Infrastructure.Services;

internal class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _accessor;
    private readonly string? _accessToken;
    private readonly JwtSecurityTokenHandler _jwtHandler = new();

    public CurrentUserService(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
        var authHeader = accessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString();

        if (!string.IsNullOrWhiteSpace(authHeader))
        {
            _accessToken = authHeader["Bearer ".Length..].Trim();
        }
    }

    public Task<string?> GetCurrentUserId()
    {
        return string.IsNullOrWhiteSpace(_accessToken)
            ? Task.FromResult<string?>(null)
            : Task.FromResult(_jwtHandler.ReadJwtToken(_accessToken).Claims.FirstOrDefault(x => x.Type == "id")?.Value);
    }

    public async Task<bool> IsAuthorized()
    {
        if (string.IsNullOrWhiteSpace(_accessToken))
        {
            return await Task.FromResult(false);
        }

        var result = await _jwtHandler.ValidateTokenAsync(_accessToken, GetValidationParameters());

        return result.IsValid;
    }

    private TokenValidationParameters GetValidationParameters()
        => new ()
        {
            ClockSkew = TimeSpan.Zero,
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = true,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supermegasecretkey")),
            ValidateIssuerSigningKey = true,
        };
}