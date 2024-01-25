using ConfigCentric.Api.Extensions;
using ConfigCentric.Api.Models;
using ConfigCentric.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace ConfigCentric.Api.AppService;
public class ConfigValueAppService
{
    private readonly ConfigCentricDbContext dbContext;

    public ConfigValueAppService(ConfigCentricDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ConfigValue> Update(Guid id, string name, string value, string? description)
    {
        var configValue = await dbContext.ConfigValues
            .Include(o => o.Environment)
            .FindModelAsync(id);
        configValue.Name = name;
        configValue.Value = value;
        configValue.Description = description;

        await dbContext.SaveChangesAsync();
        return configValue;
    }
    public async Task Delete(Guid id)
    {
        var configValue = await dbContext.ConfigValues.FindModelAsync(id);
        dbContext.ConfigValues.Remove(configValue);
        await dbContext.SaveChangesAsync();
    }
    public async Task<List<ConfigValueSummary>> GetAllByEnvironment(Guid environmentId)
    {
        var environments = await dbContext.ConfigValues
            .Include(x => x.Environment)
            .Where(o => o.Environment.Id == environmentId)
            .Select(x => new ConfigValueSummary(x.Name, x.Value, x.Description, x.Id, x.CreatedAt))
            .ToListAsync();
        return environments;
    }
}