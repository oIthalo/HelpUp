using Flunt.Validations;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string fullname)
    {
        var name = fullname.ToString().Split(" ");
        FirstName = name[0];
        LastName = name[1];

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsNotNullOrEmpty(FirstName, "Name.FirstName", "Nome não pode estar vazio")
            .IsGreaterThan(FirstName.Length, 3, "Name.FirstName", "Nome deve ter pelo menos 2 caracteres")
            .IsLowerThan(FirstName.Length, 24, "Name.FirstName", "Nome deve ter no máximo 24 caracteres")
            .IsNotNullOrEmpty(LastName, "Name.LastName", "Sobrenome não pode estar vazio")
            .IsGreaterThan(LastName.Length, 3, "Name.FirstName", "Nome deve ter pelo menos 2 caracteres")
            .IsLowerThan(LastName.Length, 36, "Name.FirstName", "Nome deve ter no máximo 100 caracteres"));
    }

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsNotNullOrEmpty(FirstName, "Name.FirstName", "Nome não pode estar vazio")
            .IsGreaterThan(FirstName.Length, 3, "Name.FirstName", "Nome deve ter pelo menos 2 caracteres")
            .IsLowerThan(FirstName.Length, 24, "Name.FirstName", "Nome deve ter no máximo 24 caracteres")
            .IsNotNullOrEmpty(LastName, "Name.LastName", "Sobrenome não pode estar vazio")
            .IsGreaterThan(LastName.Length, 3, "Name.FirstName", "Nome deve ter pelo menos 2 caracteres")
            .IsLowerThan(LastName.Length, 36, "Name.FirstName", "Nome deve ter no máximo 100 caracteres"));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString() => $"{FirstName} {LastName}";
}