using ConfigCentric.Api.Extensions;
using ConfigCentric.Api.Models;
using ConfigCentric.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Environment = ConfigCentric.Api.Models.Environment;

namespace ConfigCentric.Api.AppService;
public class EnvironmentAppService
{
    private readonly ConfigCentricDbContext dbContext;

    public EnvironmentAppService(ConfigCentricDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Environment> Update(Guid id, string name, string? description)
    {
        var environment = await dbContext.Environments
            .Include(o => o.Project)
            .FindModelAsync(id);
        environment.Name = name;
        environment.Description = description;

        await dbContext.SaveChangesAsync();
        return environment;
    }
    public async Task Delete(Guid id)
    {
        var environment = await dbContext.Environments.FindModelAsync(id);
        dbContext.Environments.Remove(environment);
        await dbContext.SaveChangesAsync();
    }
    public async Task<List<EnvironmentSummary>> GetAllByProject(Guid projectId)
    {
        var environments = await dbContext.Environments
            .Include(x => x.Project)
            .Where(o => o.Project.Id == projectId)
            .Select(x => new EnvironmentSummary(x.Name, x.Description, x.Id, x.CreatedAt))
            .ToListAsync();
        return environments;
    }

    public async Task<ConfigValue> AddConfig(string name, string value, Guid environmentId, string? description)
    {
        var environment = await dbContext.Environments.FindModelAsync(environmentId);
        var configValue = new ConfigValue(name, value, environment);
        if (description != null)
            configValue.Description = description;

        await dbContext.ConfigValues.AddAsync(configValue);
        await dbContext.SaveChangesAsync();
        return configValue;
    }
}
