namespace AviaSales.Application.Common.Models.Users;

public class UserProfile
{
    public Guid Id { get; init; }

    public string UserName { get; init; }

    public string Email { get; init; }

    public string AccessToken { get; init; }

    public UserProfile(Guid id, string userName, string email, string accessToken)
    {
        Id = id;
        UserName = userName;
        Email = email;
        AccessToken = accessToken;
    }
}