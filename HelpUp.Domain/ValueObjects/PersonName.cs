using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class PersonName : ValueObject
{
    public PersonName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}