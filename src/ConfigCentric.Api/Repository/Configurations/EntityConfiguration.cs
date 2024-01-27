using ConfigCentric.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigCentric.Api.Repository.Configurations;

public abstract class EntityConfiguration <TType>
    : IEntityTypeConfiguration<TType>
    where TType : Entity
{

    public void Configure(EntityTypeBuilder<TType> builder)
    {
        builder.HasQueryFilter(p => !p.IsDeleted);

        ConfigureDerived(builder);
    }
    public abstract void ConfigureDerived(EntityTypeBuilder<TType> builder);

}
