using Microsoft.AspNetCore.Identity;

namespace AviaSales.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public IEnumerable<Ticket>? Tickets { get; set; }
}