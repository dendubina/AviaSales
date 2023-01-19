using AviaSales.Domain.Entities;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviaSales.Infrastructure.Persistence.Configuration;

internal class UsersConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var user = new User
        {
            Id = new Guid("557710e6-1b91-4344-8bc4-a75c68a5a165"),
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "awestruck31@mail.ru",
            NormalizedEmail = "AWESTRUCK31@MAIL.RU",
            EmailConfirmed = true,
            SecurityStamp = new Faker().Random.String(10).ToUpperInvariant(),
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "1");

        builder.HasData(user);
    }
}