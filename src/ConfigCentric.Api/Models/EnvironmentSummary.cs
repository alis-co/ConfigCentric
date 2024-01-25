namespace ConfigCentric.Api.Models;

public record EnvironmentSummary(
    string Name, 
    string? Description,
    Guid Id,
    DateTimeOffset CreatedAt);