using Flunt.Notifications;
namespace HelpUp.Shared.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public Entity()
    {
        Id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
    }

    public string Id { get; set; }
}
