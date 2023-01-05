namespace AviaSales.Application.Common.Models;

public class EmailMessage
{
    public string To { get; set; }

    public string Subject { get; set; }

    public string Message { get; set; }

    public EmailMessage(string to, string subject, string message)
    {
        To = to ?? throw new ArgumentNullException(nameof(to));
        Subject = subject ?? throw new ArgumentNullException(nameof(subject));
        Message = message ?? throw new ArgumentNullException(nameof(message));
    }
}