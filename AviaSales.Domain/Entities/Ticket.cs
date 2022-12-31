using AviaSales.Domain.Enums;

namespace AviaSales.Domain.Entities;

public class Ticket
{
    public Guid Id { get; set; }

    public int SeatNumber { get; set; }

    public User? Owner { get; set; }

    public Guid OwnerId { get; set; }

    public Route? Route { get; set; }

    public Guid RouteId { get; set; }

    public TicketStatus TicketStatus { get; set; }
}