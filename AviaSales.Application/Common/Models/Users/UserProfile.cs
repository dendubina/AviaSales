namespace AviaSales.Application.Common.Models.Users;

public class UserProfile
{
    public Guid Id { get; init; }

    public string UserName { get; init; }

    public string Email { get; init; }

    public string AccessToken { get; init; }

    public UserProfile(Guid id, string userName, string email, string accessToken)
    {        
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id must not be empty", nameof(id));
        }

        Id = id;
        UserName = userName ?? throw new ArgumentNullException(nameof(userName), "UserName must not be null");
        Email = email ?? throw new ArgumentNullException(nameof(email), "Email must not be null");
        AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken), "AccessToken must not be null");
    }
}