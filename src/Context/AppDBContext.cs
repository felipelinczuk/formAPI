using formAPI.src.Models;
using Microsoft.EntityFrameworkCore;

namespace formAPI;

public class AppDBContext : DbContext
{
    public DbSet<Person> People {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        IConfiguration configuration = 
            new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true)
                    .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
    }
}
