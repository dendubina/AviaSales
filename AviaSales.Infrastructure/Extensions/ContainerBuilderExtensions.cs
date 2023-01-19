using System.Data;
using Autofac;
using AviaSales.Application.Common.Interfaces;
using AviaSales.Domain.Repositories;
using AviaSales.Infrastructure.Persistence;
using AviaSales.Infrastructure.Services;
using AviaSales.Infrastructure.Services.Options;
using AviaSales.Infrastructure.Services.Repositories;
using Braintree;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;

namespace AviaSales.Infrastructure.Extensions;

internal static class ContainerBuilderExtensions
{
    public static ContainerBuilder ConfigureRepositories(this ContainerBuilder builder)
    {
        builder.RegisterType<TicketsRepository>().As<ITicketsRepository>()
            .InstancePerLifetimeScope();

        return builder;
    }

    public static ContainerBuilder ConfigureAppDbContext(this ContainerBuilder builder)
    {
        builder.Register(context =>
        {
            var config = context.Resolve<IConfiguration>();
            var optsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optsBuilder.UseNpgsql(config.GetConnectionString("Postgres"),
                    opt => opt.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
                .UseLowerCaseNamingConvention();

            return new AppDbContext(optsBuilder.Options);
        }).AsSelf().InstancePerLifetimeScope();

        return builder;
    }

    public static ContainerBuilder ConfigureSqlConnection(this ContainerBuilder builder)
    {
        builder.Register(context =>
        {
            var connectionString = context.Resolve<IConfiguration>().GetConnectionString("Postgres");

            return new NpgsqlConnection(connectionString);
        }).As<IDbConnection>().SingleInstance();

        return builder;
    }

    public static ContainerBuilder ConfigureBrainTreeGateway(this ContainerBuilder builder)
    {
        builder.Register(context => new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = "9xnq7thvsfzb79w6",
            PublicKey = "sgv255xfwzmf4qcy",
            PrivateKey = "57bf2f9a97a41329f723055d4633f0b7"
        }).As<IBraintreeGateway>().SingleInstance();

        builder.RegisterType<BrainTreePayments>().As<IPaymentSystem>()
            .SingleInstance();

        return builder;
    }

    public static ContainerBuilder ConfigureEmailService(this ContainerBuilder builder)
    {
        builder.Register(context =>
        {
            var config = context.Resolve<IConfiguration>();

            return Options.Create(config.GetSection(nameof(EmailOptions)).Get<EmailOptions>());
        }).AsSelf().SingleInstance();

        builder.RegisterType<SmtpClient>().As<ISmtpClient>()
            .SingleInstance();

        builder.RegisterType<EmailService>().As<IEmailService>()
            .InstancePerLifetimeScope();

        return builder;
    }
}