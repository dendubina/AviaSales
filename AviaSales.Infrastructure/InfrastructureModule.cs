using Autofac;
using AviaSales.Infrastructure.Extensions;

namespace AviaSales.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.ConfigureAppDbContext();

        builder.ConfigureSqlConnection();
    }
}