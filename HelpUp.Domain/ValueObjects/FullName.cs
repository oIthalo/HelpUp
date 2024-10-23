using Flunt.Validations;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class FullName : ValueObject
{
    public FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<FullName>()
            .Requires()
            .IsNotNullOrEmpty(FirstName, "FullName.FirstName", "Nome não pode estar vazio")
            .IsNotNullOrEmpty(LastName, "FullName.LastName", "Sobrenome não pode estar vazio"));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}