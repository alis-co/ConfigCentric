namespace ConfigCentric.Api.Models;

public class Entity
{
    public Entity()
    {
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    public void Delete()
    {
        IsDeleted = true;
        DeletedAt = DateTimeOffset.UtcNow;
    }
}