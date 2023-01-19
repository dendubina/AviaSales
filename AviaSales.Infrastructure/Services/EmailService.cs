using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Common.Models;
using AviaSales.Infrastructure.Services.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Text;

namespace AviaSales.Infrastructure.Services;

internal class EmailService : IEmailService
{
    private readonly ISmtpClient _smtpClient;
    private readonly EmailOptions _options;

    public EmailService(ISmtpClient smtpClient, IOptions<EmailOptions> emailOptions)
    {
        _smtpClient = smtpClient;
        _options = emailOptions.Value;
    }

    public async Task Send(EmailMessage message)
    {
        await _smtpClient.ConnectAsync(_options.Host, _options.Port);
        await _smtpClient.AuthenticateAsync(_options.UserName, _options.Password);

        var mimeMessage = new MimeMessage
        {
            From = { new MailboxAddress(Encoding.UTF8, _options.FromName, _options.UserName) },
            To = { new MailboxAddress(Encoding.UTF8,message.To, message.To) },
            Subject = message.Subject,
            Body = new BodyBuilder { HtmlBody = message.Text }.ToMessageBody()
        };

        await _smtpClient.SendAsync(mimeMessage);
        await _smtpClient.DisconnectAsync(quit: true);
    }
}