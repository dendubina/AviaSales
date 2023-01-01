using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Common.Models.Users;
using AviaSales.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AviaSales.Infrastructure.Services.Identity;

internal class IdentityService : IIdentityService
{
    readonly UserManager<User> _userManager;

    public IdentityService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public Task<UserProfile> SignInAsync(SignInModel model)
    {
        throw new NotImplementedException();
    }

    public Task<UserProfile> SignUpAsync(SignUpModel model)
    {
        throw new NotImplementedException();
    }
}