using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PierresAuth.Models
{
  public class PierresAuthContextFactory : IDesignTimeDbContextFactory<PierresAuthContext>
  {
    PierresAuthContext IDesignTimeDbContextFactory<PierresAuthContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PierresAuthContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new PierresAuthContext(builder.Options);
    }
  }
}