namespace ConfigCentric.Api.Dto;

public class ConfigValueSummaryDto
{
    public string Name { get; set; }
    public string Value { get; set; }
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}


