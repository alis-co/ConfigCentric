namespace ConfigCentric.Api.Models;

public record ProjectSummary(
    string Name, 
    string? Description, 
    Guid Id,
    DateTimeOffset CreatedAt);