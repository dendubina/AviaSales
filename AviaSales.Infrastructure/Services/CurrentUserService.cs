using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AviaSales.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Serilog;

namespace AviaSales.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly string? _accessToken;
    private readonly JwtSecurityTokenHandler _jwtHandler = new();


    public string? Id =>
        string.IsNullOrWhiteSpace(_accessToken)
            ? null
            : _jwtHandler.ReadJwtToken(_accessToken).Claims.FirstOrDefault(x => x.Type == "id")?.Value;

    public string? Email =>
        string.IsNullOrWhiteSpace(_accessToken)
            ? null
            : _jwtHandler.ReadJwtToken(_accessToken).Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

    public CurrentUserService(IHttpContextAccessor accessor, ILogger logger)
    {
        var authHeader = accessor.HttpContext?.Request?.Headers[HeaderNames.Authorization].ToString();

        if (!string.IsNullOrWhiteSpace(authHeader))
        {
            var accessToken = authHeader.Replace(oldValue: "Bearer", newValue: string.Empty).Trim();
            
            if (_jwtHandler.CanReadToken(accessToken))
            {
                _accessToken = accessToken;
            }
            else
            {
                 logger.Warning("Attempt to authorize using invalid token: {authHeader}", authHeader);
            }
        }
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