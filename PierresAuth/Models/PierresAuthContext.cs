using Microsoft.EntityFrameworkCore;

namespace PierresAuth.Models
{ 
  public class PierresAuthContext : DbContext  
  {
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<Treat> Treats { get; set; }
    public DbSet<FlavorTreat> FlavorTreat { get; set; }
    public PierresAuthContext(DbContextOptions options) : base(options) { }
  }
}