using AviaSales.Domain.Enums;

namespace AviaSales.Domain.Entities;

public class Ticket<TUser, TKey>
    where TUser : class
    where TKey : IEquatable<TKey>
{
    public Guid Id { get; set; }

    public int SeatNumber { get; set; }

    public TUser? Owner { get; set; }

    public TKey? OwnerId { get; set; }

    public TicketStatus TicketStatus { get; set; }
}