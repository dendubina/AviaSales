namespace AviaSales.Application.Planes.Dto;

public class PlaneWithRouteDto
{
    public Guid Id { get; set; }

    public string? Model { get; set; }

    public int SeatsCount { get; set; }
}