using System.Data;
using AviaSales.Application.Common.Extensions;
using AviaSales.Application.Routes.Dto;
using FluentValidation;

namespace AviaSales.Application.Routes.Commands.CreateRoute;

internal class CreateUpdateRouteDtoValidator : AbstractValidator<CreateUpdateRouteDto>
{
    public CreateUpdateRouteDtoValidator(IDbConnection dbConnection)
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Arrival)
            .GreaterThan(x => x.Departure);

        RuleFor(x => x.FromId)
           .MustAsync(async (fromId, _) => await dbConnection.IsEntityExists("locations", fromId))
           .WithMessage("'From' location doesn't exist");

        RuleFor(x => x.ToId)
            .MustAsync(async (toId, _) => await dbConnection.IsEntityExists("locations", toId))
            .WithMessage("'To' location doesn't exist");

        RuleFor(x => x.PlaneId)
            .MustAsync(async (planeId, _) => await dbConnection.IsEntityExists("planes", planeId))
            .WithMessage("Plane doesn't exists");
    }
}