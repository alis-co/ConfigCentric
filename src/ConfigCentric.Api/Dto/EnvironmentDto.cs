namespace ConfigCentric.Api.Dto;

public class EnvironmentDto
{
    public string Name { get; set; }
    public Guid ProjectId { get; private set; }
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}


