using AviaSales.Application.Common.Interfaces;
using MediatR;

namespace AviaSales.Application.Payments.Queries;

public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
{
    private readonly IPaymentSystem _paymentSystem;

    public GetTokenQueryHandler(IPaymentSystem paymentSystem)
    {
        _paymentSystem = paymentSystem;
    }

    public Task<string> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        => _paymentSystem.GenerateTokenAsync();
}