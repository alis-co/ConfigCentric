using System.Collections.ObjectModel;

namespace ConfigCentric.Api.Models;
public class Project : Entity
{
    protected Project()
    {
        environments = new List<Environment>();
    }
    public Project(string name)
    {
        Name = name;
        environments = new List<Environment>();
    }

    private List<Environment> environments;

    public string Name { get; set; }
    public List<Environment> Environments
    {
        get
        {
            if (environments == null)
                environments = new List<Environment>()  ;
            return environments;
        }
    }

    public void AddEnvironment(Environment environment)
    {
        environments.Add(environment);
    }
}
