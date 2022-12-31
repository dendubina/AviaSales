using MediatR;

namespace AviaSales.Application.Routes.Commands.CreateRoute;

public class CreateRouteCommand : IRequest
{
    public CreateUpdateRouteDto CreateRouteDto { get; init; }

    public CreateRouteCommand(CreateUpdateRouteDto dto)
    {
        CreateRouteDto = dto ?? throw new ArgumentNullException(nameof(dto));
    }
}