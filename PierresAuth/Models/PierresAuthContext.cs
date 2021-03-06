using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PierresAuth.Models
{ 
  public class PierresAuthContext : IdentityDbContext<ApplicationUser> 
  {
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<Treat> Treats { get; set; }
    public DbSet<FlavorTreat> FlavorTreats { get; set; }
    public PierresAuthContext(DbContextOptions options) : base(options) { }
  }
}