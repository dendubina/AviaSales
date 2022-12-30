using AviaSales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviaSales.Infrastructure.Persistence.Configuration;

internal class PlanesConfig : IEntityTypeConfiguration<Plane>
{
    public void Configure(EntityTypeBuilder<Plane> builder)
    {
        builder.Property(x => x.Model).IsRequired();

        builder.HasData(DataInitializer.Planes);
    }
}