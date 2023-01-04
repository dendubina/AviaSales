using System.Data;
using AviaSales.Application.Tickets.Dto;
using AviaSales.Application.Tickets.Validators;
using FluentValidation;

namespace AviaSales.Application.Tickets.Commands.BuyTicket;

internal class BuyTicketDtoValidator : CreateTicketDtoValidator<BuyTicketDto>
{
    public BuyTicketDtoValidator(IDbConnection connection) : base(connection)
    {
        RuleFor(x => x.Nonce)
            .NotNull().NotEmpty();
    }
}