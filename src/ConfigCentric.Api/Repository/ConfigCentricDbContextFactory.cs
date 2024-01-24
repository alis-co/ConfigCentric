using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace ConfigCentric.Api.Repository;
    public class ConfigCentricDbContextFactory
        : IDesignTimeDbContextFactory<ConfigCentricDbContext>
    {
         public ConfigCentricDbContext CreateDbContext(string[] args)
    {
        string cs = Environment.GetEnvironmentVariable("CC_CONNECTIONSTRING");
    
;


        if (cs == null)
            throw new InvalidOperationException("Provide connection string via CC_CONNECTIONSTRING env var");

        DbContextOptions<ConfigCentricDbContext> options
            = new DbContextOptionsBuilder<ConfigCentricDbContext>()
                .UseNpgsql(cs)
                .Options;

        return new ConfigCentricDbContext(options);
    }
    }
