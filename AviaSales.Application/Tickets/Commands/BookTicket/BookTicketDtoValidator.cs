using System.Data;
using AviaSales.Application.Common.Extensions;
using AviaSales.Application.Tickets.Dto;
using Dapper;
using FluentValidation;

namespace AviaSales.Application.Tickets.Commands.BookTicket;

internal class BookTicketDtoValidator : AbstractValidator<BookTicketDto>
{
    private readonly IDbConnection _dbConnection;

    public BookTicketDtoValidator(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.RouteId)
            .NotEmpty()
            .MustAsync((routeId, _) => dbConnection.IsEntityExistsAsync("routes", routeId))
            .WithMessage(model => $"Route with id '{model.RouteId}' not found");

        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.SeatNumber)
            .GreaterThan(0)
            .MustAsync((model, _, _) => SeatExists(model.SeatNumber, model.RouteId))
            .WithMessage(model => $"Seat with number {model.SeatNumber} doesn't exist")
            .MustAsync((model, _, _) => SeatAvailable(model.SeatNumber, model.RouteId))
            .WithMessage(model => $"Seat {model.SeatNumber} doesn't available");
    }

    private async Task<bool> SeatExists(int selectedSeatNumber, Guid routeId)
    {
        const string query = "SELECT planes.seatsCount FROM routes " +
                             "JOIN planes ON planes.id = routes.planeId " +
                            $"WHERE routes.id = @{nameof(routeId)} " +
                             "LIMIT 1";

        var seatsCount = await _dbConnection.ExecuteScalarAsync<int>(query, new { routeId });

        return seatsCount >= selectedSeatNumber;
    }

    private async Task<bool> SeatAvailable(int seatNumber, Guid routeId)
    {
        const string query = "SELECT t.id FROM tickets t " +
                            $"WHERE t.routeId = @{nameof(routeId)} AND t.seatNumber = @{nameof(seatNumber)}";

        var existedTicketId = await _dbConnection.QueryFirstOrDefaultAsync<Guid>(query, new { routeId, seatNumber });

        return existedTicketId == Guid.Empty;
    }
}