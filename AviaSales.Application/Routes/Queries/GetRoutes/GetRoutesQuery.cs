using MediatR;

namespace AviaSales.Application.Routes.Queries.GetRoutes;

public class GetRoutesQuery : IRequest<IEnumerable<GetRouteDto>>
{
    public RouteParameters Parameters { get; }

    public GetRoutesQuery(RouteParameters parameters)
    {
        Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
    }
}