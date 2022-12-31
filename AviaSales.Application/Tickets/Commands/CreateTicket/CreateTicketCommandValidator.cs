using System.Data;
using FluentValidation;

namespace AviaSales.Application.Tickets.Commands.CreateTicket
{
    internal class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator(IDbConnection dbConnection)
        {
            RuleFor(x => x.CreateTicketDto)
                .NotNull()
                .SetValidator(new CreateTicketDtoValidator(dbConnection));
        }
    }
}
