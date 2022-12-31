using AviaSales.Application.Routes.Dto;
using MediatR;

namespace AviaSales.Application.Routes.Commands.CreateRoute;

public class CreateRouteCommand : IRequest<Guid>
{
    public CreateUpdateRouteDto CreateRouteDto { get; init; }

    public CreateRouteCommand(CreateUpdateRouteDto dto)
    {
        CreateRouteDto = dto ?? throw new ArgumentNullException(nameof(dto));
    }
}