using System.Data;
using FluentValidation;
using System.Data.Common;
using AviaSales.Application.Common.Extensions;

namespace AviaSales.Application.Routes.Commands.DeleteRoute;

internal class DeleteRouteCommandValidator : AbstractValidator<DeleteRouteCommand>
{
    public DeleteRouteCommandValidator(IDbConnection connection)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(async (fromId, _) => await connection.IsEntityExistsAsync("routes", fromId));
    }
}