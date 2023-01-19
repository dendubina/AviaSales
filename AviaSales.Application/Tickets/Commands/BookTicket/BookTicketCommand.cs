using AviaSales.Application.Common.Attributes;
using AviaSales.Application.Tickets.Dto;
using MediatR;

namespace AviaSales.Application.Tickets.Commands.BookTicket;

[Authorize]
public class BookTicketCommand : IRequest<Guid>
{
    public CreateTicketDtoBase CreateTicketDto { get; }

    public BookTicketCommand(CreateTicketDtoBase dto)
    {
        CreateTicketDto = dto ?? throw new ArgumentNullException(nameof(dto));
    }
}