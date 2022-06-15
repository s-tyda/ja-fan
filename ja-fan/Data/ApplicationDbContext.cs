using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ja_fan.Models;

namespace ja_fan.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ja_fan.Models.Country>? Country { get; set; }
    public DbSet<ja_fan.Models.Team>? Team { get; set; }
    public DbSet<ja_fan.Models.Nickname>? Nickname { get; set; }
}