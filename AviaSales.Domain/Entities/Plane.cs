namespace AviaSales.Domain.Entities;

public class Plane
{
    public Guid Id { get; set; }

    public string? Model { get; set; }

    public int SeatsCount { get; set; }
}