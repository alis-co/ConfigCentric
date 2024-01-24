namespace ConfigCentric.Api.Dto;

public class ProjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<EnvironmentDto> Environments { get; set; }
}

