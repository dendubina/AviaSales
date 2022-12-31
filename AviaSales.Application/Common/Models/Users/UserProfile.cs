namespace AviaSales.Application.Common.Models.Users;

public class UserProfile
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? JwtToken { get; set; }
}