using AviaSales.Application.Routes.Dto;
using MediatR;

namespace AviaSales.Application.Routes.Queries.GetRouteById
{
    public class GetRouteByIdQuery : IRequest<GetRouteDto?>
    {
        public Guid Id { get; init; }

        public GetRouteByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
