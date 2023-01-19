namespace AviaSales.Application.Common.Models;

public class EmailMessage
{
    public string To { get; set; }

    public string Subject { get; set; }

    public string Text { get; set; }

    public EmailMessage(string to, string subject, string text)
    {
        To = to ?? throw new ArgumentNullException(nameof(to));
        Subject = subject ?? throw new ArgumentNullException(nameof(subject));
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }
}