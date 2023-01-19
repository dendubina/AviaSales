using System.Data;
using FluentValidation;

namespace AviaSales.Application.Tickets.Commands.BuyTicket;

internal class BuyTicketCommandValidator : AbstractValidator<BuyTicketCommand>
{
    public BuyTicketCommandValidator(IDbConnection connection)
    {
        RuleFor(x => x.BuyTicketDto)
            .NotNull()
            .SetValidator(new BuyTicketDtoValidator(connection));
    }
}