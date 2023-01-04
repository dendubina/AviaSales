using AviaSales.Domain.Entities;
using AviaSales.Domain.Repositories;
using AviaSales.Infrastructure.Persistence;

namespace AviaSales.Infrastructure.Services.Repositories;

public class TicketsRepository : ITicketsRepository
{
    readonly AppDbContext _appDbContext;

    public TicketsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Ticket> AddAsync(Ticket ticket)
    {
        await _appDbContext.Tickets.AddAsync(ticket);
        await SaveChangesAsync();

        return ticket;
    }

    public Task SaveChangesAsync()
        => _appDbContext.SaveChangesAsync();
}