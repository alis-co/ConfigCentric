using AutoMapper;
using ConfigCentric.Api.AppService;
using ConfigCentric.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<EnvironmentDto> Update(Guid id, [FromBody] UpdateEnvironmentInput input)
    {
        var project = await service.Update(id, input.Name, input.Description);
        var dto = mapper.Map<EnvironmentDto>(project);
        return dto;
    }
    [HttpDelete]
    public async Task Delete(Guid id)
    {
        await service.Delete(id);
    }
    [HttpGet]
    public async Task<List<EnvironmentSummaryDto>> GetAllByProject(Guid projectId)
    {
        var environments = await service.GetAllByProject(projectId);
        var dto = mapper.Map<List<EnvironmentSummaryDto>>(environments);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}/configs/add")]
    public async Task<ConfigValueDto> AddConfig(Guid id,[FromBody] CreateConfigValueInput input)
    {
        var project = await service.AddConfig(input.Name, input.Value, id, input.Description);
        var dto = mapper.Map<ConfigValueDto>(project);
        return dto;
    }
}