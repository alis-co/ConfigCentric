using ConfigCentric.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigCentric.Api.Repository.Configurations;
public class ProjectConfiguration 
    : EntityConfiguration<Project>
{
    public override void ConfigureDerived(EntityTypeBuilder<Project> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(p=> p.ApiKey).IsUnique();
    }
}
