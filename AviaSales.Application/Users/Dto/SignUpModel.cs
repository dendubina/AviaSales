namespace AviaSales.Application.Users.Dto;

public class SignUpModel
{
    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? PasswordConfirm { get; set; }
}