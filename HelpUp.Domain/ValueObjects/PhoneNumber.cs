using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public PhoneNumber(string number)
    {
        Number = number;
    }

    public string Number { get; private set; }

    public override string ToString()
    {
        return Number;
    }
}