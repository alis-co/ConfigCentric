using ConfigCentric.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigCentric.Api.Repository.Configurations;

public class ConfigValueConfiguration :
    EntityConfiguration<ConfigValue>
{
    public override void ConfigureDerived(EntityTypeBuilder<ConfigValue> builder)
    {
       builder.HasIndex("Name", "EnvironmentId").IsUnique();
    }
}
