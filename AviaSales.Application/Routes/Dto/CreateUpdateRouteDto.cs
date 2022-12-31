namespace AviaSales.Application.Routes.Dto;

public class CreateUpdateRouteDto
{
    public DateTime Departure { get; set; }

    public DateTime Arrival { get; set; }

    public Guid FromId { get; set; }

    public Guid ToId { get; set; }

    public Guid PlaneId { get; set; }
}