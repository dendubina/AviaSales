using System.Reflection;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace AviaSales.Api.Extensions;

internal static class ContainerBuilderExtensions
{
    public static void ConfigureMediatR(this ContainerBuilder builder)
    {
        var config = MediatRConfigurationBuilder
            .Create(Assembly.GetExecutingAssembly())
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

        builder.RegisterMediatR(config);
    }
}