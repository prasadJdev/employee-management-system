using employeeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace employeeProject.data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
        
        public DbSet<People> People { get; set; }

        public DbSet<Requests> Requests { get; set; }
        
        public DbSet<Files> Files { get; set; }
    }
    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {//Extra
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }*/
}
