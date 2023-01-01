using FluentValidation;

namespace AviaSales.Application.Routes.Commands.DeleteRoute;

internal class DeleteRouteCommandValidator : AbstractValidator<DeleteRouteCommand>
{
    public DeleteRouteCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}