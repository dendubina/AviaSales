using Autofac;
using System.Reflection;
using AviaSales.Application.Common.Behaviors;
using FluentValidation;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace AviaSales.Application.Common.Extensions;

internal static class ContainerBuilderExtensions
{
    public static ContainerBuilder ConfigureMediatR(this ContainerBuilder builder)
    {
        var config = MediatRConfigurationBuilder
            .Create(Assembly.GetExecutingAssembly())
            .WithCustomPipelineBehavior(typeof(ExceptionHandlingBehavior<,>))
            .WithCustomPipelineBehavior(typeof(ValidationBehaviour<,>))
            .WithCustomPipelineBehavior(typeof(AuthorizationBehavior<,>))
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

        builder.RegisterMediatR(config);

        return builder;
    }

    public static ContainerBuilder ConfigureFluentValidation(this ContainerBuilder builder)
    {
        ValidatorOptions.Global.LanguageManager.Enabled = false;

        builder
            .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        return builder;
    }

    public static ContainerBuilder ConfigureSerilog(this ContainerBuilder builder)
    {
        builder.Register<ILogger>(context =>
        {
            var connectionString = context.Resolve<IConfiguration>().GetConnectionString("Postgres");

            return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.PostgreSQL(connectionString, tableName: "logs", needAutoCreateTable: true)
                .CreateLogger();
        }).SingleInstance();

        return builder;
    }
}