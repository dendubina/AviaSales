namespace AviaSales.Application.Tickets.Dto;

public class BuyTicketDto : CreateTicketDtoBase
{
    public string? Nonce { get; set; }
}