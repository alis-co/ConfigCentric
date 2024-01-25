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

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ConfigValueDto> Update(Guid id, [FromBody] UpdateConfigValueInput input)
    {
        var project = await service.Update(id, input.Name, input.Value, input.Description);
        var dto = mapper.Map<ConfigValueDto>(project);
        return dto;
    }
    [HttpDelete]
    public async Task Delete(Guid id)
    {
        await service.Delete(id);
    }
    [HttpGet]
    public async Task<List<ConfigValueSummaryDto>> GetAllByEnvironment(Guid environmentId)
    {
        var configValues = await service.GetAllByEnvironment(environmentId);
        var dto = mapper.Map<List<ConfigValueSummaryDto>>(configValues);
        return dto;
    }
}
