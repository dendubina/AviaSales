using Braintree;
using MediatR;

namespace AviaSales.Application.Payments.Queries;

public class GetTokenQueryHandler : RequestHandler<GetTokenQuery, string>
{
    private readonly BraintreeGateway _gateway;

    public GetTokenQueryHandler(BraintreeGateway gateway)
    {
        _gateway = gateway;
    }

    protected override string Handle(GetTokenQuery request)
        => _gateway.ClientToken.Generate();
}