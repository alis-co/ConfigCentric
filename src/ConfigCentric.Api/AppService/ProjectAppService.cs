using ConfigCentric.Api.Extensions;
using ConfigCentric.Api.Models;
using ConfigCentric.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Environment = ConfigCentric.Api.Models.Environment;


namespace ConfigCentric.Api.AppService;
public class ProjectAppService
{
    private readonly ConfigCentricDbContext dbContext;

    public ProjectAppService(ConfigCentricDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Project> Create(string name, string? description)
    {
        var project = new Project(name);
        if (description != null)
            project.Description = description;

        await dbContext.Projects.AddAsync(project);
        await dbContext.SaveChangesAsync();
        return project;
    }
    public async Task<Project> Update(Guid id, string name, string? description)
    {
        var project = await dbContext.Projects.FindModelAsync(id);
        project.Name = name;
        project.Description = description;

        await dbContext.SaveChangesAsync();
        return project;
    }
    public async Task<Project> AddEnvironment(string name, Guid projectId, string? description)
    {
        var project = await dbContext.Projects
            .Include(x => x.Environments)
            .FindModelAsync(projectId);
        var environment = new Environment(name, project);
        if (description != null)
            environment.Description = description;

        project.AddEnvironment(environment);
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
            .Select(x => new ProjectSummary(x.Name, x.Description, x.Id, x.CreatedAt))
            .ToListAsync();

        return projects;
    }
}

