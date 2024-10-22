namespace HelpUp.Shared.Entities;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
    }

    public string Id { get; set; }
}
