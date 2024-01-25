namespace ConfigCentric.Api.Models;

public record ConfigValueSummary(
    string Name, 
    string Value, 
    string? Description, 
    Guid Id,
    DateTimeOffset CreatedAt);