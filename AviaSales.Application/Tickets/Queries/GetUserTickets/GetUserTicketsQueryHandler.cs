using System.Data;
using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Tickets.Dto;
using Dapper;
using MediatR;

namespace AviaSales.Application.Tickets.Queries.GetUserTickets;

internal class GetUserTicketsQueryHandler : IRequestHandler<GetUserTicketsQuery, IEnumerable<GetTicketDto>>
{
    private readonly IDbConnection _dbConnection;
    private readonly ICurrentUserService _currentUser;

    public GetUserTicketsQueryHandler(IDbConnection dbConnection, ICurrentUserService currentUserService)
    {
        _dbConnection = dbConnection;
        _currentUser = currentUserService;
    }

    public async Task<IEnumerable<GetTicketDto>> Handle(GetUserTicketsQuery request, CancellationToken cancellationToken)
    {
        const string query = "SELECT " +
                             "t.id, t.seatNumber, t.ticketStatus, r.arrival, r.departure, fromLoc.name AS from, toLoc.name AS to " +
                             "FROM tickets t " +
                             "JOIN routes r ON r.id = t.routeId " +
                             "JOIN locations fromLoc ON r.fromId = fromLoc.id " +
                             "JOIN locations toLoc ON r.toId = toLoc.id " +
                             "WHERE ownerId = @userId";

        var userId = new Guid(_currentUser.Id);

        return await _dbConnection.QueryAsync<GetTicketDto>(query, new { userId });
    }
}