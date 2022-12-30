using Autofac;
using AviaSales.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AviaSales.Infrastructure.Extensions;

internal static class ContainerBuilderExtensions
{
    public static void ConfigureAppDbContext(this ContainerBuilder builder)
    {
        builder.Register(c =>
        {
            var config = c.Resolve<IConfiguration>();
            var optsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                optsBuilder.UseInMemoryDatabase("InMemoryDatabase");
            }
            else
            {
                /* optsBuilder.UseNpgsql(config.GetConnectionString("Postgres"),
                     opt => opt.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));*/

                optsBuilder.UseSqlServer(config.GetConnectionString("Mssql"),
                    opt => opt.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            }

            return new AppDbContext(optsBuilder.Options);
        }).AsSelf().InstancePerLifetimeScope();


    }
}