namespace ConfigCentric.Api.Dto;

public class ConfigValueDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public Guid EnvironmentId { get; private set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}


