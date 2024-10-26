using Flunt.Validations;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class Description : ValueObject
{
    public Description(string desc)
    {
        Desc = desc;

        AddNotifications(new Contract<Description>()
            .Requires()
            .IsNotNullOrEmpty(Desc, "Description.Desc", "Descrição não pode estar vazia"));
    }

    public string Desc { get; private set; }

    public override string ToString() => Desc;
}