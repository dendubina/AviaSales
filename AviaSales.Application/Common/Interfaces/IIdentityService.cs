using AviaSales.Application.Common.Models;
using AviaSales.Application.Users.Dto;

namespace AviaSales.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<AuthResult> SignInAsync(SignInModel model);

    Task<AuthResult> SignUpAsync(SignUpModel model);
}