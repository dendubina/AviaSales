using AviaSales.Application.Common.Models.Users;

namespace AviaSales.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserProfile> SignInAsync(SignInModel model);

        Task<UserProfile> SignUpAsync(SignUpModel model);
    }
}
