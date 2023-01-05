using AviaSales.Application.Common.Models;

namespace AviaSales.Application.Common.Interfaces;

public interface IEmailService
{
    Task Send(EmailMessage message);
}