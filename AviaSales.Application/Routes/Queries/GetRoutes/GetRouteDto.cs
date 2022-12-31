using AviaSales.Application.Planes.Dto;

namespace AviaSales.Application.Routes.Queries.GetRoutes;

public class GetRouteDto
{
    public Guid Id { get; set; }

    public DateTime Departure { get; set; }

    public DateTime Arrival { get; set; }

    public string? From { get; set; }

    public string? To { get; set; }

    public PlaneWithRouteDto? Plane { get; set; }
}