using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Environment = ConfigCentric.Api.Models.Environment;

namespace ConfigCentric.Api.Repository.Configurations;

public class EnvironmentConfiguration :
    EntityConfiguration<Environment>
{
    public override void ConfigureDerived(EntityTypeBuilder<Environment> builder)
    {
         builder.HasIndex("Name", "ProjectId").IsUnique();
    }
}
