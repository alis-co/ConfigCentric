using AutoMapper;
using ConfigCentric.Api.Dto;
using ConfigCentric.Api.Models;
using Environment = ConfigCentric.Api.Models.Environment;

namespace ConfigCentric.Api;
public class ConfigCentricMappingProfile : Profile
{
    public ConfigCentricMappingProfile()
    {
        CreateMap<Project, ProjectDto>();
        CreateMap<Environment, EnvironmentDto>();
        CreateMap<ConfigValue, ConfigValueDto>();
        CreateMap<ConfigValueSummary, ConfigValueSummaryDto>();
        CreateMap<EnvironmentSummary, EnvironmentSummaryDto>();
        CreateMap<ProjectSummary, ProjectSummaryDto>();
        // CreateMap<List<Project>, List<ProjectDto>>();
    }
}
