using AviaSales.Domain.Enums;

namespace AviaSales.Application.Tickets.Dto;

public class GetUserTicketDto
{
    public Guid Id { get; set; }

    public string? From { get; set; }

    public string? To { get; set; }

    public DateTime Arrival { get; set; }

    public DateTime Departure { get; set; }

    public int SeatNumber { get; set; }

    public TicketStatus TicketStatus { get; set; }
}