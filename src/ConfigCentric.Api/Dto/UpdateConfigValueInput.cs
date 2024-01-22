namespace ConfigCentric.Api.Dto;

public class UpdateConfigValueInput
{
public string Name { get; set; }
public string Value { get; set; }
 public Guid EnvironmentId { get; private set; }
}

