using AviaSales.Application.Routes.Dto;
using MediatR;

namespace AviaSales.Application.Routes.Commands.UpdateRoute;

public class UpdateRouteCommand : IRequest
{
    public Guid Id { get; }

    public CreateUpdateRouteDto UpdateRouteDto { get; }

    public UpdateRouteCommand(Guid id, CreateUpdateRouteDto dto)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Guid is empty", nameof(id));
        }

        UpdateRouteDto = dto ?? throw new ArgumentNullException(nameof(dto));
        Id = id;
    }
}