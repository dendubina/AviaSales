using AviaSales.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IntegrationTests;

public class AppFixture : IDisposable
{
    public CustomWebApplicationFactory Factory { get; } 

    public AppDbContext AppDbContext { get; }

    public AppFixture()
    {
        Factory = new CustomWebApplicationFactory();

        AppDbContext = Factory.Services.GetRequiredService<AppDbContext>();
        AppDbContext.Database.EnsureCreated();
    }

    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        var mediator = Factory.Services.GetRequiredService<ISender>();
        return await mediator.Send(request);
    }

    public void Dispose()
    {
        AppDbContext.Database.EnsureDeleted();
        Factory.Dispose();
    }
}