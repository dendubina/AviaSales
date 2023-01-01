using System.Data;
using FluentValidation;

namespace AviaSales.Application.Tickets.Commands.BookTicket
{
    internal class BookTicketCommandValidator : AbstractValidator<BookTicketCommand>
    {
        public BookTicketCommandValidator(IDbConnection dbConnection)
        {
            RuleFor(x => x.CreateTicketDto)
                .NotNull()
                .SetValidator(new BookTicketDtoValidator(dbConnection));
        }
    }
}
