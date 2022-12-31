using MediatR;

namespace AviaSales.Application.Tickets.Queries.GetUserTickets;

internal class GetUserTicketsQuery : IRequest<IEnumerable<GetUserTicketDto>>
{
    public Guid UserId { get; init; }

    public GetUserTicketsQuery(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException($"{nameof(userId)} is empty");
        }

        UserId = userId;
    }
}