using Autofac;
using AviaSales.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;

namespace Application.IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public IConfiguration Configuration { get; set; }

    public Mock<ICurrentUserService> CurrentUserMock { get; } = new();

    public Mock<IPaymentSystem> PaymentSystemMock { get; } = new();

    public Mock<IEmailService> EmailServiceMock { get; } = new();


    protected override IHost CreateHost(IHostBuilder builder)
    {
        
        builder.UseServiceProviderFactory<ContainerBuilder>(new AutofacServiceProviderFactory());
        return base.CreateHost(builder);
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(configurationBuilder =>
        {
            var integrationConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.tests.json")
                .AddEnvironmentVariables()
                .Build();

            configurationBuilder.AddConfiguration(integrationConfig);
        });

        builder.ConfigureServices((builder, services) =>
        {
            Configuration = builder.Configuration;
        });

        builder.ConfigureTestContainer<ContainerBuilder>(builder =>
        {
            builder.Register(context => CurrentUserMock.Object).As<ICurrentUserService>()
                .InstancePerLifetimeScope();

            builder.Register(context => PaymentSystemMock.Object).As<IPaymentSystem>()
                .InstancePerLifetimeScope();

            builder.Register(context => EmailServiceMock.Object).As<IEmailService>()
                .InstancePerLifetimeScope();
        });
    }

    private class AutofacServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
    {
        private readonly Autofac.Extensions.DependencyInjection.AutofacServiceProviderFactory _wrapped;
        private IServiceCollection _services;

        public AutofacServiceProviderFactory()
        {
            _wrapped = new Autofac.Extensions.DependencyInjection.AutofacServiceProviderFactory();
        }

        public ContainerBuilder CreateBuilder(IServiceCollection services)
        {
            _services = services;

            return _wrapped.CreateBuilder(services);
        }

        public IServiceProvider CreateServiceProvider(ContainerBuilder containerBuilder)
        {
            var sp = _services.BuildServiceProvider();
            var filters = sp.GetRequiredService<IEnumerable<IStartupConfigureContainerFilter<ContainerBuilder>>>();

            foreach (var filter in filters)
            {
                filter.ConfigureContainer(b => { })(containerBuilder);
            }

            return _wrapped.CreateServiceProvider(containerBuilder);
        }
    }
}