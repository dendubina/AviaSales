using System.Data;
using MediatR;

namespace AviaSales.Application.Tickets.Queries.GetUserTickets;

internal class GetUserTicketsQueryHandler : IRequestHandler<GetUserTicketsQuery, IEnumerable<GetUserTicketDto>>
{
    readonly IDbConnection _dbConnection;

    public GetUserTicketsQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public Task<IEnumerable<GetUserTicketDto>> Handle(GetUserTicketsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}