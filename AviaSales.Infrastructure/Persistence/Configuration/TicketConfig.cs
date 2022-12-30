using AviaSales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviaSales.Infrastructure.Persistence.Configuration;

internal class TicketConfig : IEntityTypeConfiguration<Ticket<User, Guid>>
{
    public void Configure(EntityTypeBuilder<Ticket<User, Guid>> builder)
    {
           
    }
}