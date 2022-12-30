using System.Reflection;
using AviaSales.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AviaSales.Infrastructure.Persistence;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Ticket<User, Guid>> Tickets => Set<Ticket<User, Guid>>();
    public DbSet<Route> Routes => Set<Route>();

    public AppDbContext(DbContextOptions options) : base(options)
    {
        base.Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}