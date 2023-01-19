namespace AviaSales.Application.Tickets.Dto;

public class CreateTicketDtoBase
{
    public Guid RouteId { get; set; } // = new("0759077a-e2d5-6d44-e39b-2867e9137ab2");

    public int SeatNumber { get; set; } // = new Random().Next(1, 15);
}