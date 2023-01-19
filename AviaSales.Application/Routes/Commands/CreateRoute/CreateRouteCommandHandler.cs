using System.Data;
using Dapper;
using MediatR;

namespace AviaSales.Application.Routes.Commands.CreateRoute;

internal class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, Guid>
{
    private readonly IDbConnection _dbConnection;

    public CreateRouteCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Guid> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
    {
        const string query = "INSERT INTO routes (id, arrival, departure, fromid, toid, planeid, price) " +
                             "VALUES (gen_random_uuid (), @Arrival, @Departure, @FromId, @ToId, @PlaneId, @Price) " +
                             "RETURNING Id";

        var parameters = new DynamicParameters();
        parameters.Add("Price", request.CreateRouteDto.Price, DbType.Decimal);
        parameters.Add("Arrival", request.CreateRouteDto.Arrival, DbType.DateTime);
        parameters.Add("Departure", request.CreateRouteDto.Departure, DbType.DateTime);
        parameters.Add("FromId", request.CreateRouteDto.FromId, DbType.Guid);
        parameters.Add("ToId", request.CreateRouteDto.ToId, DbType.Guid);
        parameters.Add("PlaneId", request.CreateRouteDto.PlaneId, DbType.Guid);

        return await _dbConnection.ExecuteScalarAsync<Guid>(query, parameters);
    }
}