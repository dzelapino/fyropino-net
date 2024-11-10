using fyropinonet.Models;
using Microsoft.EntityFrameworkCore;
using Task = fyropinonet.Models.Task;

namespace fyropinonet.Controllers.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    
    public DbSet<Contractor> Contractors { get; set; }
    
    public DbSet<Task> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>()
            .HasMany(x => x.Contractors)
            .WithMany(x => x.Tasks)
            .UsingEntity(j => j.ToTable("ContractorTask"));
    }
}