using ConfigCentric.Api.Extensions;
using ConfigCentric.Api.Models;
using ConfigCentric.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace ConfigCentric.Api.AppService;
public class ConfigValueAppService : ServiceBase<ConfigValue>
{
    public ConfigValueAppService(ConfigCentricDbContext dbContext) : base(dbContext)
    {
  
    }

    public async Task<ConfigValue> Update(Guid id, string name, string value, string? description)
    {
        var configValue = await dbContext.ConfigValues
            .Include(o => o.Environment)
            .FindModelAsync(id);

        if (dbContext.ConfigValues.Any(
                x => x.Name.ToLower() == name.ToLower()
                && x.Id != configValue.Id 
                && x.Environment.Id == configValue.Environment.Id))
            throw new Exception($"The name: {name} is already used, enter another name.");

        configValue.Name = name;
        configValue.Value = value;
        configValue.Description = description;

        await dbContext.SaveChangesAsync();
        return configValue;
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
