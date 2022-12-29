using AviaSales.Domain.Entities;

namespace AviaSales.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
