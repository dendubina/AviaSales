using AviaSales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviaSales.Infrastructure.Persistence.Configuration
{
    internal class RoutesConfig : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            /* builder
                 .HasOne<Location>()
                 .WithMany(x => x.FromRoutes)
                 .HasForeignKey(x => x.FromId);

             builder
                 .HasOne<Location>()
                 .WithMany(x => x.ToRoutes)
                 .HasForeignKey(x => x.ToId);*/

            builder.HasData(DataInitializer.Routes);
        }
    }
}
