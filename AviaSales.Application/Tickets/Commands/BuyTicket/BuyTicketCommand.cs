using AviaSales.Application.Common.Attributes;
using AviaSales.Application.Tickets.Dto;
using MediatR;

namespace AviaSales.Application.Tickets.Commands.BuyTicket;

[Authorize]
public class BuyTicketCommand : IRequest<Guid>
{
    public BuyTicketDto BuyTicketDto { get; }

    public BuyTicketCommand(BuyTicketDto dto)
    {
        BuyTicketDto = dto ?? throw new ArgumentNullException(nameof(dto));
    }
}