using AutoMapper;
using ConfigCentric.Api.AppService;
using ConfigCentric.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ConfigCentric.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class ProjectController : Controller
{
    private readonly ProjectAppService service;
    private readonly IMapper mapper;

    public ProjectController(ProjectAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }
    [HttpPost]
    public async Task<ProjectDto> Create([FromBody] CreateProjectInput input)
    {
        var project = await service.Create(input.Name);
        var dto = mapper.Map<ProjectDto>(project);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ProjectDto> Update(Guid id, [FromBody] UpdateProjectInput input)
    {
        var project = await service.Update(id, input.Name);
        var dto = mapper.Map<ProjectDto>(project);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}/environments/add")]
    public async Task<ProjectDto> AddEnvironment(Guid id, [FromBody] CreateEnvironmentInput input)
    {
        var project = await service.AddEnvironment(input.Name, id);
        var dto = mapper.Map<ProjectDto>(project);
        return dto;
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await service.Delete(id);
    }
    [HttpGet]
    public async Task<List<ProjectSummaryDto>> GetAll()
    {
        var projects = await service.GelAll();
        var dto = mapper.Map<List<ProjectSummaryDto>>(projects);
        return dto;
    }
}
