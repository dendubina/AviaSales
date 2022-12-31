using System.Data;
using FluentValidation;

namespace AviaSales.Application.Routes.Commands.CreateRoute
{
    internal class CreateRouteCommandValidator : AbstractValidator<CreateRouteCommand>
    {
        public CreateRouteCommandValidator(IDbConnection dbConnection)
        {
            RuleFor(x => x.CreateRouteDto)
                .NotNull();

            RuleFor(x => x.CreateRouteDto)
                .SetValidator(new CreateUpdateRouteDtoValidator(dbConnection));
        }
    }
}
