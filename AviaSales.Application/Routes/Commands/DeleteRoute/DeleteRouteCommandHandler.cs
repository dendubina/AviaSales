using System.Data;
using Dapper;
using MediatR;

namespace AviaSales.Application.Routes.Commands.DeleteRoute;

internal class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand>
{
    readonly IDbConnection _dbConnection;

    public DeleteRouteCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
    {
        const string query = "DELETE FROM routes " +
                             "WHERE id = @Id";

        await _dbConnection.ExecuteAsync(query, new { request.Id });

        return Unit.Value;
    }
}