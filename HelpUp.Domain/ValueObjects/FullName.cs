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
            .IsGreaterThan(FirstName.Length, 3, "FullName.FirstName", "Nome deve ter pelo menos 2 caracteres")
            .IsLowerThan(FirstName.Length, 24, "FullName.FirstName", "Nome deve ter no máximo 24 caracteres")
            .IsNotNullOrEmpty(LastName, "FullName.LastName", "Sobrenome não pode estar vazio")
            .IsGreaterThan(LastName.Length, 3, "FullName.FirstName", "Nome deve ter pelo menos 2 caracteres")
            .IsLowerThan(LastName.Length, 36, "FullName.FirstName", "Nome deve ter no máximo 100 caracteres"));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString() => $"{FirstName} {LastName}";
}