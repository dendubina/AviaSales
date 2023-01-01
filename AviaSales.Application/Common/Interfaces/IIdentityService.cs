using AviaSales.Application.Common.Models.Users;

namespace AviaSales.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<Result> SignInAsync(SignInModel model);

    Task<Result> SignUpAsync(SignUpModel model);
}