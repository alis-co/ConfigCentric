namespace ConfigCentric.Api.Dto;

public class CreateEnvironmentInput
{
    public string Name { get; set; }
    public Guid ProjectId { get; private set; }
}
