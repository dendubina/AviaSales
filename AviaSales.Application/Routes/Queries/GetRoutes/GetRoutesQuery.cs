using AviaSales.Domain.Entities;
using MediatR;

namespace AviaSales.Application.Routes.Queries.GetRoutes
{
    public class GetRoutesQuery : IRequest<IEnumerable<Route>>
    {
        private readonly RouteParameters _parameters;

        public GetRoutesQuery(RouteParameters parameters)
        {
            _parameters = parameters;
        }
    }
}
