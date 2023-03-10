using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Common.Models;
using Braintree;

namespace AviaSales.Infrastructure.Services;

public class BrainTreePayments : IPaymentSystem
{
    private readonly IBraintreeGateway _brainTreeGateway;

    public BrainTreePayments(IBraintreeGateway brainTreeGateway)
    {
        _brainTreeGateway = brainTreeGateway;
    }

    public Task<string> GenerateTokenAsync()
        => _brainTreeGateway.ClientToken.GenerateAsync();

    public async Task<PaymentResult> ExecuteAsync(string nonce, decimal amount)
    {
        var request = new TransactionRequest
        {
            Amount = amount,
            PaymentMethodNonce = nonce
        };

        var result = await _brainTreeGateway.Transaction.SaleAsync(request);

        return result.IsSuccess()
            ? PaymentResult.Success()
            : PaymentResult.Failure(result.Errors.DeepAll().Select(x => x.Message));
    }
}