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
            .IsNotNullOrEmpty(Name, "SingleName.Name", "Nome não pode estar vazio")
            .IsGreaterThan(Name.Length, 3, "SingleName.Name", "Nome deve ter pelo menos 3 caracteres")
            .IsLowerThan(Name.Length, 25, "SingleName.Name", "Nome deve ter no máximo 24 caracteres"));
    }

    public string Name { get; private set; }

    public override string ToString() => Name;
}