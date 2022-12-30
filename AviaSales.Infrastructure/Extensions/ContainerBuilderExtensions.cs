﻿using System.Data;
using Autofac;
using AviaSales.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

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
                optsBuilder.UseNpgsql(config.GetConnectionString("Postgres"),
                    opt => opt.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
                    .UseLowerCaseNamingConvention();
            }

            return new AppDbContext(optsBuilder.Options);
        }).AsSelf().InstancePerLifetimeScope();
    }

    public static void ConfigureSqlConnection(this ContainerBuilder builder)
    {
        builder.Register(c =>
        {
            var connectionString = c.Resolve<IConfiguration>().GetConnectionString("Postgres");

            return new NpgsqlConnection(connectionString);
        }).As<IDbConnection>().SingleInstance();
    }
}