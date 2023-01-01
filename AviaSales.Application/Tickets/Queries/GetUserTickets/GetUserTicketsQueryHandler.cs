using System.Data;
using Dapper;
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
        const string query = "SELECT *";
        var result = _dbConnection.QueryAsync("query");
        throw new NotImplementedException();
    }
}