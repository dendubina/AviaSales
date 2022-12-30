using AviaSales.Application.Common.Interfaces;
using AviaSales.Domain.Entities;
using AviaSales.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AviaSales.Infrastructure.Repositories;

internal class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _context.Products.ToListAsync();
}