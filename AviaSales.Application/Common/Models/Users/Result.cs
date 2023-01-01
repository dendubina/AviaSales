namespace AviaSales.Application.Common.Models.Users
{
    public class Result
    {
        public bool Succeeded { get; init; }

        public string[] Errors { get; init; }

        public UserProfile? UserProfile { get; init; }

        private Result(bool succeeded, IEnumerable<string> errors, UserProfile? profile = null)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            UserProfile = profile;
        }

        public static Result Success(UserProfile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            return new Result(succeeded: true, Array.Empty<string>(), profile);
        }

        public static Result Failure(string errorMessage)
            => Failure(new[] { errorMessage });

        public static Result Failure(IEnumerable<string> errors)
            => new Result(succeeded: false, errors);
    }
}
