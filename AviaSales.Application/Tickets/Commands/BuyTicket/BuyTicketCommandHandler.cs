using System.Data;
using AviaSales.Application.Common.Interfaces;
using AviaSales.Domain.Entities;
using AviaSales.Domain.Enums;
using AviaSales.Domain.Repositories;
using Dapper;
using MediatR;

namespace AviaSales.Application.Tickets.Commands.BuyTicket;

public class BuyTicketCommandHandler : IRequestHandler<BuyTicketCommand, Guid>
{
    private readonly IPaymentSystem _paymentSystem;
    private readonly ITicketsRepository _ticketsRepository;
    private readonly IDbConnection _dbConnection;
    private readonly ICurrentUserService _currentUserService;

    public BuyTicketCommandHandler(IPaymentSystem paymentSystem, ITicketsRepository ticketsRepository,
        IDbConnection dbConnection, ICurrentUserService currentUserService)
    {
        _paymentSystem = paymentSystem;
        _ticketsRepository = ticketsRepository;
        _dbConnection = dbConnection;
        _currentUserService = currentUserService;
    }

    public async Task<Guid> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
    {
        var price = await GetTicketPriceAsync(request.BuyTicketDto.RouteId);

        var paymentResult = await _paymentSystem.ExecuteAsync(request.BuyTicketDto.Nonce, price);

        if (!paymentResult.Succeeded)
        {
            throw new InvalidOperationException("Payment Failed");
        }

        var ticket = new Ticket
        {
            OwnerId = new Guid(await _currentUserService.GetCurrentUserId()),
            RouteId = request.BuyTicketDto.RouteId,
            SeatNumber = request.BuyTicketDto.SeatNumber,
            TicketStatus = TicketStatus.Bought,
        };

        var created = await _ticketsRepository.AddAsync(ticket);
        return created.Id;

    }

    private async Task<decimal> GetTicketPriceAsync(Guid routeId)
    {
        const string query = "SELECT price from routes r " +
                             "WHERE r.Id = @routeId " +
                             "LIMIT 1";

        return await _dbConnection.ExecuteScalarAsync<decimal>(query, new { routeId });
    }
}