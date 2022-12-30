using Autofac;
using AviaSales.Application.Common.Interfaces;
using AviaSales.Infrastructure.Extensions;
using AviaSales.Infrastructure.Persistence;

namespace AviaSales.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        /* builder.RegisterType<ProductRepository>().As<IProductRepository>()
             .InstancePerLifetimeScope();*/

        builder.RegisterType<DbConnectionAccessor>().As<IDbConnectionAccessor>()
            .SingleInstance();

        builder.ConfigureAppDbContext();
    }
}