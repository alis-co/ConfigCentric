using ConfigCentric.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfigCentric.Api.Repository;
public class ConfigCentricDbContext : DbContext
{
    public ConfigCentricDbContext(DbContextOptions options)
: base(options)
    {

    }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {

    // }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Models.Environment> Environments { get; set; }
    public DbSet<ConfigValue> ConfigValues { get; set; }
}
