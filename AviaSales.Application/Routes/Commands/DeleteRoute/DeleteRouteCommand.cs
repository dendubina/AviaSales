using MediatR;

namespace AviaSales.Application.Routes.Commands.DeleteRoute;

public class DeleteRouteCommand : IRequest
{
    public Guid Id { get; init; }

    public DeleteRouteCommand(Guid id)
    {
        Id = id;
    }
}