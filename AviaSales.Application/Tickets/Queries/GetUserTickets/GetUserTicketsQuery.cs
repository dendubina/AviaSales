using AviaSales.Application.Common.Attributes;
using AviaSales.Application.Tickets.Dto;
using MediatR;

namespace AviaSales.Application.Tickets.Queries.GetUserTickets;

[Authorize]
public class GetUserTicketsQuery : IRequest<IEnumerable<GetUserTicketDto>>
{
    
}