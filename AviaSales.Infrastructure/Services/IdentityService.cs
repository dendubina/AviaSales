using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Common.Models;
using AviaSales.Application.Users.Dto;
using AviaSales.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AviaSales.Infrastructure.Services;

internal class IdentityService : IIdentityService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public IdentityService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<AuthResult> SignInAsync(SignInModel userData)
    {
        var user = await _userManager.FindByEmailAsync(userData.Email);

        if (user is null)
        {
            return AuthResult.Failure("User not found");
        }

        var result = await _signInManager.PasswordSignInAsync(user, userData.Password, isPersistent: false, lockoutOnFailure: false);

        return result.Succeeded
            ? AuthResult.Success(await CreateProfile(user))
            : AuthResult.Failure("Password is invalid");
    }

    public async Task<AuthResult> SignUpAsync(SignUpModel userData)
    {
        var userToCreate = new User
        {
            UserName = userData.UserName,
            Email = userData.Email,
        };

        var result = await _userManager.CreateAsync(userToCreate, userData.Password);

        return result.Succeeded
            ? AuthResult.Success(await CreateProfile(userToCreate))
            : AuthResult.Failure(result.Errors.Select(x => x.Description));
    }

    private async Task<UserProfile> CreateProfile(User user)
    {
        return new UserProfile(user.Id, user.UserName, user.Email,
            new JwtSecurityTokenHandler().WriteToken(await GenerateJwtTokenAsync(user)));
    }

    private async Task<JwtSecurityToken> GenerateJwtTokenAsync(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supermegasecretkey"));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.Now.Add(TimeSpan.FromMinutes(15));

        return new JwtSecurityToken(
            claims: await GetClaimsAsync(user),
            expires: expires,
            signingCredentials: credentials
        );
    }

    private async Task<IEnumerable<Claim>> GetClaimsAsync(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim( "id", user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim("role", role)));

        return claims;
    }
}