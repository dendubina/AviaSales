using System.Data;
using AviaSales.Application.Planes.Dto;
using AviaSales.Application.Routes.Dto;
using Dapper;
using MediatR;

namespace AviaSales.Application.Routes.Queries.GetRoutes;

internal class GetRoutesQueryHandler : IRequestHandler<GetRoutesQuery, IEnumerable<GetRouteDto>>
{
    private readonly IDbConnection _dbConnection;

    public GetRoutesQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<GetRouteDto>> Handle(GetRoutesQuery request, CancellationToken cancellationToken)
    {
        var queryBuilder = new SqlBuilder();
        var template = queryBuilder.AddTemplate("SELECT " +
                                 "routes.id, fr.name as From, s.name as To, arrival, departure, planes.id, planes.model, planes.seatscount " +
                                 "FROM routes " +
                                 "JOIN locations fr ON routes.fromid = fr.id " +
                                 "JOIN locations s ON routes.toid = s.id " +
                                 "JOIN planes ON planes.id = routes.planeid " +
                                 "/**where**/");

        if (!string.IsNullOrWhiteSpace(request.Parameters.From))
        {
            queryBuilder.Where("fr.name = @From", new { request.Parameters.From });
        }

        if (!string.IsNullOrWhiteSpace(request.Parameters.To))
        {
            queryBuilder.Where("s.name = @To", new { request.Parameters.To });
        }

        var result = await _dbConnection.QueryAsync<GetRouteDto, PlaneWithRouteDto, GetRouteDto>(template.RawSql,
            (route, plane) =>
            {
                route.Plane = plane;
                return route;
            }, template.Parameters);

        return result;
    }
}