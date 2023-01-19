namespace AviaSales.Application.Common.Models;

public class AuthResult
{
    public bool Succeeded { get; init; }

    public string[] Errors { get; init; }

    public UserProfile? UserProfile { get; init; }

    private AuthResult(bool succeeded, IEnumerable<string> errors, UserProfile? profile = null)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
        UserProfile = profile;
    }

    public static AuthResult Success(UserProfile profile)
    {
        if (profile is null)
        {
            throw new ArgumentNullException(nameof(profile));
        }

        return new AuthResult(succeeded: true, errors: Array.Empty<string>(), profile);
    }

    public static AuthResult Failure(string errorMessage)
        => Failure(new[] { errorMessage });

    public static AuthResult Failure(IEnumerable<string> errors)
        => new AuthResult(succeeded: false, errors);
}