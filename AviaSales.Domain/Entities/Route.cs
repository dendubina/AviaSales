namespace AviaSales.Domain.Entities;

public class Route
{
    public Guid Id { get; set; }

    public DateTime Arrival { get; set; }

    public DateTime Departure { get; set; }

    public Guid FromId { get; set; }

    public Guid ToId { get; set; }

    public Location From { get; set; }

    public Location To { get; set; }

    public Guid PlaneId { get; set; }

    public Plane? Plane { get; set; }
}