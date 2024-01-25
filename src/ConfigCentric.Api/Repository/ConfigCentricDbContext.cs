using ConfigCentric.Api.Models;
using Microsoft.EntityFrameworkCore;
using Environment = ConfigCentric.Api.Models.Environment;


namespace ConfigCentric.Api.Repository;
public class ConfigCentricDbContext : DbContext
{
    public ConfigCentricDbContext(DbContextOptions options)
: base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasIndex(x=> x.Name).IsUnique();
        modelBuilder.Entity<Environment>().HasIndex("Name","ProjectId").IsUnique();
        modelBuilder.Entity<ConfigValue>().HasIndex("Name","EnvironmentId").IsUnique();
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Models.Environment> Environments { get; set; }
    public DbSet<ConfigValue> ConfigValues { get; set; }
}
