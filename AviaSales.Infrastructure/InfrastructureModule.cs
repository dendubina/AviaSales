using Autofac;
using AviaSales.Application.Common.Interfaces;
using AviaSales.Infrastructure.Extensions;
using AviaSales.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace AviaSales.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.ConfigureAppDbContext();

        builder.ConfigureSqlConnection();

        builder.RegisterType<IdentityService>().As<IIdentityService>()
            .InstancePerLifetimeScope();

        builder.RegisterType<CurrentUserService>().As<ICurrentUserService>()
            .InstancePerLifetimeScope();

        builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>()
            .SingleInstance();
    }
}