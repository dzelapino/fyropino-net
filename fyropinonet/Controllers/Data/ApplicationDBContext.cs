using fyropinonet.Models;
using Microsoft.EntityFrameworkCore;
using Task = fyropinonet.Models.Task;

namespace fyropinonet.Controllers.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    
    public DbSet<Contractor> Contractors { get; set; }
    
    public DbSet<Task> Tasks { get; set; }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Contractor>().HasData(
    //         new Contractor
    //         {
    //             Id = 1, Address = "Klonowa 4d/21", Color = "green", Email = "dzelapino@mail.su",
    //             ShortName = "dzelapino", FullName = "dzelapino sp. zło", Phone = "500500100"
    //         }
    //     );
    // }
}