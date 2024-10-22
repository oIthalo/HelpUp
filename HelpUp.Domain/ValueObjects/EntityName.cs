namespace HelpUp.Domain.ValueObjects;

public class EntityName
{
    public EntityName(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public override string ToString()
    {
        return Name;
    }
}