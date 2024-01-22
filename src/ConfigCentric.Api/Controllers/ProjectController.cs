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
    public ProjectDto Create([FromBody] CreateProjectInput input)
    {
        var project = service.Create(input.Name);
        var dto = mapper.Map<ProjectDto>(project);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}")]
    public ProjectDto Update(Guid id, string name, Guid? environmentId)
    {
        var project = service.Update(id, name, environmentId);
        var dto = mapper.Map<ProjectDto>(project);
        return dto;
    }
    [HttpDelete]
    public async Task Delete(Guid id)
    {
        await service.Delete(id);
    }
    [HttpGet]
    public async Task<ProjectSummaryDto> GetAllByProject()
    {
        var projects = service.GelAll();
        var dto = mapper.Map<ProjectSummaryDto>(projects);
        return dto;
    }
}
