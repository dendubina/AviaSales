using AviaSales.Application.Tickets.Dto;
using MediatR;

namespace AviaSales.Application.Tickets.Commands.BuyTicket;

public class BuyTicketCommand : IRequest<Guid>
{
    public BuyTicketDto BuyTicketDto { get; }

    public BuyTicketCommand(BuyTicketDto dto)
    {
        BuyTicketDto = dto ?? throw new ArgumentNullException(nameof(dto));
    }
}