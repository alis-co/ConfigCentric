namespace ConfigCentric.Api.Models;

public class Environment : Entity
{
    public Environment(string name, Project project)
    {
        Name = name;
        Project = project;
    }

    public string Name { get; set; }
    public Project Project {get; private set;}
    public List<ConfigValue> ConfigValues { get; set; }
}

