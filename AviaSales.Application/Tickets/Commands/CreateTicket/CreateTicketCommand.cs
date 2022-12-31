using MediatR;

namespace AviaSales.Application.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommand : IRequest
    {
        public CreateTicketDto CreateTicketDto { get; init; }

        public CreateTicketCommand(CreateTicketDto dto)
        {
            CreateTicketDto = dto ?? throw new ArgumentNullException(nameof(dto));
        }
    }
}
