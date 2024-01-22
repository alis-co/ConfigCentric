using ConfigCentric.Api.Extensions;
using ConfigCentric.Api.Models;
using ConfigCentric.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace ConfigCentric.Api.AppService;
public class ProjectAppService
{
    private readonly ConfigCentricDbContext dbContext;

    public ProjectAppService(ConfigCentricDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Project> Create(string name)
    {
        var project = new Project(name);
        await dbContext.Projects.AddAsync(project);
        await dbContext.SaveChangesAsync();
        return project;
    }
    public async Task<Project> Update(Guid id, string name, Guid? environmentId)
    {
        var project = await dbContext.Projects.FindModelAsync(id);
        if (environmentId.HasValue)
        {
            var environment = await dbContext.Environments.FindModelAsync(environmentId.Value);
            project.AddEnvironment(environment);
        }
        project.Name = name;
        await dbContext.SaveChangesAsync();
        return project;
    }
    public async Task Delete(Guid id)
    {
        var project = await dbContext.Projects.FindModelAsync(id);
        dbContext.Projects.Remove(project);
        await dbContext.SaveChangesAsync();
    }
    public async Task<List<ProjectSummary>> GelAll()
    {
        var projects = await dbContext.Projects
            .Include(x => x.Environments)
            .Select(x => new ProjectSummary(x.Name, x.Id))
            .ToListAsync();

        return projects;
    }
}

