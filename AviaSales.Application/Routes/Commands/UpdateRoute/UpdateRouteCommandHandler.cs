using System.Data;
using Dapper;
using MediatR;

namespace AviaSales.Application.Routes.Commands.UpdateRoute;

internal class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand>
{
    readonly IDbConnection _dbConnection;

    public UpdateRouteCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Unit> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
    {
        const string query = "UPDATE routes " +
                             "SET arrival = @Arrival, departure = @Departure, fromid = @FromId, toid = @ToId, planeid = @PlaneId, price = @Price " +
                             "WHERE id = @Id";

        var parameters = new DynamicParameters();
        parameters.Add("Id", request.Id, DbType.Guid);
        parameters.Add("Price", request.UpdateRouteDto.Price, DbType.Decimal);
        parameters.Add("Arrival", request.UpdateRouteDto.Arrival, DbType.DateTime);
        parameters.Add("Departure", request.UpdateRouteDto.Departure, DbType.DateTime);
        parameters.Add("FromId", request.UpdateRouteDto.FromId, DbType.Guid);
        parameters.Add("ToId", request.UpdateRouteDto.ToId, DbType.Guid);
        parameters.Add("PlaneId", request.UpdateRouteDto.PlaneId, DbType.Guid);

        await _dbConnection.ExecuteAsync(query, parameters);

        return Unit.Value;
    }
}