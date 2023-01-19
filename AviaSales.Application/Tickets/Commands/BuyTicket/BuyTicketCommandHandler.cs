using System.Data;
using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Common.Models;
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
    private readonly ICurrentUserService _currentUser;
    private readonly IEmailService _emailService;

    public BuyTicketCommandHandler(IPaymentSystem paymentSystem, ITicketsRepository ticketsRepository,
        IDbConnection dbConnection, ICurrentUserService currentUserService, IEmailService emailService)
    {
        _paymentSystem = paymentSystem;
        _ticketsRepository = ticketsRepository;
        _dbConnection = dbConnection;
        _currentUser = currentUserService;
        _emailService = emailService;
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
            OwnerId = new Guid(_currentUser.Id),
            RouteId = request.BuyTicketDto.RouteId,
            SeatNumber = request.BuyTicketDto.SeatNumber,
            TicketStatus = TicketStatus.Bought,
        };

        var created = await _ticketsRepository.AddAsync(ticket);

        SendMessageToUser();

        return created.Id;
    }

    private async Task<decimal> GetTicketPriceAsync(Guid routeId)
    {
        const string query = "SELECT price from routes r " +
                             "WHERE r.Id = @routeId " +
                             "LIMIT 1";

        return await _dbConnection.ExecuteScalarAsync<decimal>(query, new { routeId });
    }

    private void SendMessageToUser()
    {
        const string message = "Thank you for buying ticket!";

        _emailService.Send(new EmailMessage(to: _currentUser.Email, subject: "Ticket", message));
    }
}