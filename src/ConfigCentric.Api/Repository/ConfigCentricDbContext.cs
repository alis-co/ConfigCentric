using ConfigCentric.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfigCentric.Api.Repository;
public class ConfigCentricDbContext : DbContext
{
    public ConfigCentricDbContext(DbContextOptions options)
: base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Project>()
        //     .HasMany(o=> o.Environments)
        //     .WithOne(O=> O.Project);

        // modelBuilder.Entity<Project>()
        //     .Property(x=> x.Environments)
        //     .HasField("environment");
        //     // .UsePropertyAccessMode(PropertyAccessMode.Field);      
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Models.Environment> Environments { get; set; }
    public DbSet<ConfigValue> ConfigValues { get; set; }
}
