namespace ConfigCentric.Api.Models;

public class Entity
{
    public Entity()
    {
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}