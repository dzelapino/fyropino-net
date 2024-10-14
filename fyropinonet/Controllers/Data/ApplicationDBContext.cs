using fyropinonet.Models;
using Microsoft.EntityFrameworkCore;

namespace fyropinonet.Controllers.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    
    public DbSet<Hero> Heroes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hero>().HasData(
            new Hero { Id = 1, Name = "Darth Jar Jar", IsForceUser = true },
            new Hero { Id = 2, Name = "Jedi Bob", IsForceUser = true },
            new Hero { Id = 3, Name = "Gonk", IsForceUser = false }
        );
    }
}