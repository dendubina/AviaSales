using AviaSales.Application.Tickets.Dto;
using MediatR;

namespace AviaSales.Application.Tickets.Commands.BookTicket
{
    public class BookTicketCommand : IRequest<Guid>
    {
        public BookTicketDto CreateTicketDto { get; init; }

        public BookTicketCommand(BookTicketDto dto)
        {
            CreateTicketDto = dto ?? throw new ArgumentNullException(nameof(dto));
        }
    }
}
