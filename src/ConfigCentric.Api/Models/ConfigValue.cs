namespace ConfigCentric.Api.Models;
public class ConfigValue : Entity
{
    public ConfigValue(string name, string value, Environment environment)
    {
        Name = name;
        Value = value;
        Environment = environment;
    }

    public string Name {get; set;}
    public string Value {get; set;}
    public Environment Environment { get; private set; }
}