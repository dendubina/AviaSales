using System.Data;
using MediatR;

namespace AviaSales.Application.Routes.Commands.CreateRoute;

internal class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand>
{
    private readonly IDbConnection _dbConnection;

    public CreateRouteCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public Task<Unit> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}