using Flunt.Validations;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public PhoneNumber(string number)
    {
        Number = number;

        AddNotifications(new Contract<PhoneNumber>()
            .Requires()
            .IsNotNullOrEmpty(Number, "PhoneNumber.Number", "Número de contato não pode estar vazio"));
    }

    public string Number { get; private set; }

    public override string ToString()
    {
        return Number;
    }
}