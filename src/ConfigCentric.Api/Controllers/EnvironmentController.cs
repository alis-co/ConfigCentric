using AutoMapper;
using ConfigCentric.Api.AppService;
using ConfigCentric.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ConfigCentric.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class EnvironmentController : Controller
{
    private readonly EnvironmentAppService service;
    private readonly IMapper mapper;

    public EnvironmentController(EnvironmentAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public EnvironmentDto Create([FromBody] CreateEnvironmentInput input)
    {
        var project = service.Create(input.Name, input.ProjectId);
        var dto = mapper.Map<EnvironmentDto>(project);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}")]
    public EnvironmentDto Update(Guid id, [FromBody] UpdateEnvironmentInput input)
    {
        var project = service.Update(id, input.Name);
        var dto = mapper.Map<EnvironmentDto>(project);
        return dto;
    }
    [HttpDelete]
    public async Task Delete(Guid id)
    {
        await service.Delete(id);
    }
    [HttpGet]
    public async Task<EnvironmentSummaryDto> GetAllByProject(Guid projectId)
    {
        var environments = service.GetAllByProject(projectId);
        var dto = mapper.Map<EnvironmentSummaryDto>(environments);
        return dto;
    }
}