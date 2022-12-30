﻿using AviaSales.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AviaSales.Infrastructure.Persistence;

public class User : IdentityUser<Guid>
{
    public IEnumerable<Ticket<User, Guid>>? Tickets { get; set; }
}