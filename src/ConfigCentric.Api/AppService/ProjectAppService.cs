using ConfigCentric.Api.Extensions;
using ConfigCentric.Api.Models;
using ConfigCentric.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Environment = ConfigCentric.Api.Models.Environment;


namespace ConfigCentric.Api.AppService;
public class ProjectAppService : ServiceBase<Project>
{

    public ProjectAppService(ConfigCentricDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<Project> Create(string name, string? description)
    {
        if (dbContext.Projects.Any(x => x.Name.ToLower() == name.ToLower()))
            throw new Exception($"The name: {name} is already used, enter another name.");
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
        if (dbContext.Projects.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id))
            throw new Exception($"The name: {name} is already used, enter another name.");
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

        if (project.Environments.Any(x => x.Name.ToLower() == name.ToLower()))
            throw new Exception($"The name: {name} is already used, enter another name.");

        var environment = new Environment(name, project);
        if (description != null)
            environment.Description = description;

        project.AddEnvironment(environment);
        await dbContext.SaveChangesAsync();
        return project;
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

