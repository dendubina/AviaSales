using Autofac;
using AviaSales.Application.Common.Interfaces;
using AviaSales.Infrastructure.Extensions;
using AviaSales.Infrastructure.Services.Identity;
using Bogus;
using Microsoft.Extensions.Configuration;

namespace AviaSales.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.ConfigureAppDbContext();

        builder.ConfigureSqlConnection();

        builder.RegisterType<IdentityService>().As<IIdentityService>()
            .InstancePerLifetimeScope();
    }
}