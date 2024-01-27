using ConfigCentric.Api.Extensions;
using ConfigCentric.Api.Models;
using ConfigCentric.Api.Repository;

namespace ConfigCentric.Api.AppService;
public class ServiceBase<TEntity> where TEntity : Entity
{
    protected readonly ConfigCentricDbContext dbContext;

    public ServiceBase(ConfigCentricDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task Delete(Guid id)
    {
        var result = await dbContext.Set<TEntity>().FindModelAsync(id);
        result.Delete();
        await dbContext.SaveChangesAsync();
    }
}
