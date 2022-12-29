using AviaSales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviaSales.Infrastructure.Persistence.Configuration
{
    internal class ProductsConfig : IEntityTypeConfiguration<Product>
    {
        private static readonly Product[] Products =
        {
            new Product()
            {
                Id = 1,
                Name = "Apple"
            },
            new Product()
            {
                Id = 2,
                Name = "Banana"
            },
            new Product()
            {
                Id = 3,
                Name = "Orange"
            }
        };

        public void Configure(EntityTypeBuilder<Product> builder)
            => builder.HasData(Products);
    }
}
