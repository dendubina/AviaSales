using AviaSales.Application.Common.Interfaces;
using AviaSales.Domain.Entities;
using Dapper;
using MediatR;

namespace AviaSales.Application.Routes.Queries.GetRoutes;

internal class GetRoutesQueryHandler : IRequestHandler<GetRoutesQuery, IEnumerable<Route>>
{
    readonly IDbConnectionAccessor _connectionAccessor;

    public GetRoutesQueryHandler(IDbConnectionAccessor connectionAccessor)
    {
        _connectionAccessor = connectionAccessor;
    }

    public async Task<IEnumerable<Route>> Handle(GetRoutesQuery request, CancellationToken cancellationToken)
    {
        const string query = "SELECT * FROM public.routes r " +
                             "LEFT JOIN public.plane p ON p.id = r.planeid";

        var count = _connectionAccessor.Connection.Execute(query);
        var result = await _connectionAccessor.Connection.QueryAsync<Route>(query);

        return result;
    }
}