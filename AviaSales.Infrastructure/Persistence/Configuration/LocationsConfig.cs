using AviaSales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviaSales.Infrastructure.Persistence.Configuration;

internal class LocationsConfig : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Name).IsRequired();

        builder.HasData(DataInitializer.Locations);
    }
}