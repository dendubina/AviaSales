using System.Data;
using AviaSales.Application.Tickets.Dto;
using AviaSales.Application.Tickets.Validators;
using FluentValidation;

namespace AviaSales.Application.Tickets.Commands.BookTicket
{
    internal class BookTicketCommandValidator : AbstractValidator<BookTicketCommand>
    {
        public BookTicketCommandValidator(IDbConnection dbConnection)
        {
            RuleFor(x => x.CreateTicketDto)
                .NotNull()
                .SetValidator(new CreateTicketDtoValidator<CreateTicketDtoBase>(dbConnection));
        }
    }
}
