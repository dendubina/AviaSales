using System.Data;
using AviaSales.Application.Common.Interfaces;
using AviaSales.Domain.Enums;
using Dapper;
using MediatR;

namespace AviaSales.Application.Tickets.Commands.BookTicket;

internal class BookTicketCommandHandler : IRequestHandler<BookTicketCommand, Guid>
{
    private readonly IDbConnection _dbConnection;
    private readonly ICurrentUserService _currentUser;

    public BookTicketCommandHandler(IDbConnection dbConnection, ICurrentUserService currentUser)
    {
        _dbConnection = dbConnection;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(BookTicketCommand request, CancellationToken cancellationToken)
    {
        const string query = "INSERT INTO tickets (id, seatNumber, ownerId, routeId, ticketStatus) " +
                             "VALUES (gen_random_uuid (), @SeatNumber, @OwnerId, @RouteId, @TicketStatus) " +
                             "RETURNING Id";

        var parameters = new DynamicParameters();
        parameters.Add("SeatNumber", request.CreateTicketDto.SeatNumber, DbType.Int32);
        parameters.Add("OwnerId", _currentUser.Id, DbType.Guid);
        parameters.Add("RouteId", request.CreateTicketDto.RouteId, DbType.Guid);
        parameters.Add("TicketStatus", TicketStatus.Reserved, DbType.Int32);

        return await _dbConnection.ExecuteScalarAsync<Guid>(query, parameters);
    }
}