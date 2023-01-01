using System.Data;
using AviaSales.Application.Common.Extensions;
using AviaSales.Application.Routes.Commands.CreateRoute;
using FluentValidation;

namespace AviaSales.Application.Routes.Commands.UpdateRoute;

internal class UpdateRouteCommandValidator : AbstractValidator<UpdateRouteCommand>
{
    public UpdateRouteCommandValidator(IDbConnection dbConnection)
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(async (routeId, _) => await dbConnection.IsEntityExistsAsync("routes", routeId))
            .WithMessage(model => $"Route with id '{model.Id}' doesn't exist");

        RuleFor(x => x.UpdateRouteDto)
            .NotNull()
            .SetValidator(new CreateUpdateRouteDtoValidator(dbConnection));
    }
}