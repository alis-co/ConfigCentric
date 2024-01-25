namespace ConfigCentric.Api.Models;

public class Environment : Entity
{
    private List<ConfigValue> configValues;

    protected Environment()
    {

    }
    public Environment(string name, Project project)
    {
        Name = name;
        Project = project;
    }

    public string Name { get; set; }
    public Project Project {get; private set;}
    public string? Description { get; set; }
    public List<ConfigValue> ConfigValues { 
        get
        {
            if (configValues == null)
                configValues = new List<ConfigValue>()  ;
            return configValues;
        }
        set => configValues = value; }
}

