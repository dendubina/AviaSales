using System.Data;
using AviaSales.Application.Planes.Dto;
using AviaSales.Application.Routes.Dto;
using Dapper;
using MediatR;

namespace AviaSales.Application.Routes.Queries.GetRouteById;

internal class GetRouteByIdQueryHandler : IRequestHandler<GetRouteByIdQuery, GetRouteDto>
{
    readonly IDbConnection _dbConnection;

    public GetRouteByIdQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<GetRouteDto> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
    {
        const string query =
            "SELECT routes.id, fr.name as From, s.name as To, arrival, departure, planes.id, planes.model, planes.seatscount " +
            "FROM routes " +
            "JOIN locations fr ON routes.fromid = fr.id " +
            "JOIN locations s ON routes.toid = s.id " +
            "JOIN planes ON planes.id = routes.planeid " + 
           $"WHERE routes.id = @{nameof(request.Id)}";

        var result = await _dbConnection
            .QueryAsync<GetRouteDto, PlaneWithRouteDto, GetRouteDto>(query, (route, plane) =>
            {
                route.Plane = plane;
                return route;
            }, new {request.Id});

        return result.FirstOrDefault()!;
    }
}