using AviaSales.Application.Common.Models;

namespace AviaSales.Application.Common.Interfaces;

public interface IPaymentSystem
{
    Task<string> GenerateTokenAsync();

    Task<PaymentResult> ExecuteAsync(string nonce, decimal amount);
}