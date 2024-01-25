namespace ConfigCentric.Api.Dto;

public class EnvironmentSummaryDto
{
    public string Name { get; set; }
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}

