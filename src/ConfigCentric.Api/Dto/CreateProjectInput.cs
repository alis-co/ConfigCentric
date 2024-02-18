namespace ConfigCentric.Api.Dto;

public class CreateProjectInput
{
    public string Name { get; set; }
    public string? Description { get; set; }
}

public class ResolveInput
{
    public string ApiKey { get; set; }
    public string EnvironmentName { get; set; }
}


