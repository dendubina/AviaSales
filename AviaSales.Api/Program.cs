using Autofac;
using Autofac.Extensions.DependencyInjection;
using AviaSales.Api.Extensions;
using AviaSales.Application;
using AviaSales.Infrastructure;
using AviaSales.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterModule(new InfrastructureModule());
    container.RegisterModule(new ApplicationModule());
    
    container.ConfigureMediatR();
});

builder.Services.ConfigureIdentity();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { };
