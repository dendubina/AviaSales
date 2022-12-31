using Autofac;
using System.Reflection;
using AviaSales.Application.Common.Behaviors;
using FluentValidation;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace AviaSales.Application.Common.Extensions;

internal static class ContainerBuilderExtensions
{
    public static void ConfigureMediatR(this ContainerBuilder builder)
    {
        var config = MediatRConfigurationBuilder
            .Create(Assembly.GetExecutingAssembly())
            .WithCustomPipelineBehavior(typeof(ValidationBehaviour<,>))
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

        builder.RegisterMediatR(config);
    }

    public static void ConfigureFluentValidation(this ContainerBuilder builder)
    {
        ValidatorOptions.Global.LanguageManager.Enabled = false;

        builder
            .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}