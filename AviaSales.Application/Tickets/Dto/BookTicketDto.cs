namespace AviaSales.Application.Tickets.Dto;

public class BookTicketDto
{
    public Guid RouteId { get; set; } = new("01b2e03e-ced7-fd96-d389-7d7d68eb44db");

    public Guid UserId { get; set; } = new("557710e6-1b91-4344-8bc4-a75c68a5a165");

    public int SeatNumber { get; set; } = new Random().Next(1, 10);
}