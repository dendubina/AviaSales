using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Common.Models;
using MailKit.Net.Smtp;

namespace AviaSales.Infrastructure.Services;

internal class EmailService : IEmailService
{
    readonly ISmtpClient _smtpClient;

    public EmailService(ISmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }

    public Task Send(EmailMessage message)
    {
        throw new NotImplementedException();
    }
}