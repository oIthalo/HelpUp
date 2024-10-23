using Flunt.Validations;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class SingleName : ValueObject
{
    public SingleName(string name)
    {
        Name = name;

        AddNotifications(new Contract<SingleName>()
            .Requires()
            .IsNotNullOrEmpty(Name, "SingleName.Name", "Nome não pode estar vazio"));
    }

    public string Name { get; private set; }

    public override string ToString()
    {
        return Name;
    }
}