using AviaSales.Application.Tickets.Dto;
using MediatR;

namespace AviaSales.Application.Tickets.Commands.BookTicket;

public class BookTicketCommand : IRequest<Guid>
{
    public CreateTicketDtoBase CreateTicketDto { get; init; }

    public BookTicketCommand(CreateTicketDtoBase dto)
    {
        CreateTicketDto = dto ?? throw new ArgumentNullException(nameof(dto));
    }
}