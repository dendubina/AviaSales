using AviaSales.Domain.Entities;

namespace AviaSales.Domain.Repositories;

public interface ITicketsRepository
{
   // Task<IQueryable<Ticket>> GetAllAsync();

   // Task<Ticket?> GetByIdAsync(Guid id);

    Task<Ticket> AddAsync(Ticket ticket);

   // Task UpdateAsync(Ticket ticket);

   // Task DeleteAsync(Guid id);

   Task SaveChangesAsync();
}