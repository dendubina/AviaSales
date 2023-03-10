using System.Data;
using AviaSales.Domain.Entities;
using Bogus;

namespace AviaSales.Infrastructure.Persistence.Configuration;

public static class DataInitializer
{
    public static readonly IEnumerable<Location> Locations;

    public static readonly IEnumerable<Plane> Planes;

    public static readonly IEnumerable<Route> Routes;

    static DataInitializer()
    {
        Randomizer.Seed = new Random(35566);

        Locations = new Faker<Location>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Name, f => f.Address.City())
            .Generate(100);

        Planes = new Faker<Plane>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Model, f => $"{f.Vehicle.Manufacturer()} {f.Vehicle.Model()}")
            .RuleFor(x => x.SeatsCount, f => f.Random.Int(10, 50))
            .Generate(10);

        Routes = new Faker<Route>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Price, f => f.Finance.Amount(1, 100))
            .RuleFor(x => x.Departure, f => f.Date.Soon(30).ToUniversalTime())
            .RuleFor(x => x.Arrival, (f, u) => (u.Departure + f.Date.SoonTimeOnly().ToTimeSpan()).ToUniversalTime())
            .RuleFor(x => x.FromId, f => f.Random.ArrayElement(Locations.ToArray()).Id)
            .RuleFor(x => x.ToId, f => f.Random.ArrayElement(Locations.ToArray()).Id)
            .RuleFor(x => x.PlaneId, f => f.Random.ArrayElement(Planes.ToArray()).Id)
            .Generate(100);
    }
}