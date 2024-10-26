using Flunt.Validations;
using HelpUp.Shared.ValueObject;

namespace HelpUp.Domain.ValueObjects;

public class Category : ValueObject
{
    public Category(string name)
    {
        Name = name;

        AddNotifications(new Contract<Category>()
            .Requires()
            .IsNotNullOrEmpty(Name, "Category.Name", "O nome da categoria não pode ser vazio."));
    }

    public string Name { get; private set; }

    public override string ToString() => Name;
}