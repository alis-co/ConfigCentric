using ConfigCentric.Api.Models;
using ConfigCentric.Api.Repository.Configurations;
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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectConfiguration).Assembly);
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Models.Environment> Environments { get; set; }
    public DbSet<ConfigValue> ConfigValues { get; set; }
}
