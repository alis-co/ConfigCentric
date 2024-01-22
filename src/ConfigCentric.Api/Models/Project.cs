using System.Collections.ObjectModel;

namespace ConfigCentric.Api.Models;
public class Project : Entity
{
    public Project(string name)
    {
        Name = name;
    }

    private List<Environment> environments;

    public string Name { get; set; }
    public ReadOnlyCollection<Environment> Environments
    {
        get
        {
            if (environments == null)
                environments = new List<Environment>();
            return environments.AsReadOnly();
        }
    }

    public void AddEnvironment(Environment environment)
    {
        environments.Add(environment);
    }
}
