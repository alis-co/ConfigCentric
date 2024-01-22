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

    public async Task<Environment> Create(string name, Guid projectId)
    {
        var project = await dbContext.Projects.FindModelAsync(projectId);
        var environment = new Environment(name, project);
        await dbContext.Environments.AddAsync(environment);
        await dbContext.SaveChangesAsync();
        return environment;
    }
    public async Task<Environment> Update(Guid id, string name)
    {
        var environment = await dbContext.Environments.FindModelAsync(id);
        environment.Name = name;
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
            .Include(x=> x.Project)
            .Where(o=> o.Project.Id == projectId)
            .Select(x=> new EnvironmentSummary(x.Name, x.Id))
            .ToListAsync();
        return environments;
    }
}
