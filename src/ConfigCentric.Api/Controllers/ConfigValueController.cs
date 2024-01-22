using AutoMapper;
using ConfigCentric.Api.AppService;
using ConfigCentric.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ConfigCentric.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ConfigValueController : Controller
{
    private readonly ConfigValueAppService service;
    private readonly IMapper mapper;

    public ConfigValueController(ConfigValueAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public async Task<ConfigValueDto> Create([FromBody] CreateConfigValueInput input)
    {
        var project = await service.Create(input.Name, input.Value, input.EnvironmentId);
        var dto = mapper.Map<ConfigValueDto>(project);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ConfigValueDto> Update(Guid id, [FromBody] UpdateConfigValueInput input)
    {
        var project = await service.Update(id, input.Name, input.Value);
        var dto = mapper.Map<ConfigValueDto>(project);
        return dto;
    }
    [HttpDelete]
    public async Task Delete(Guid id)
    {
        await service.Delete(id);
    }
    [HttpGet]
    public async Task<ConfigValueSummaryDto> GetAllByEnvironment(Guid environmentId)
    {
        var configValues = service.GetAllByEnvironment(environmentId);
        var dto = mapper.Map<ConfigValueSummaryDto>(configValues);
        return dto;
    }
}
