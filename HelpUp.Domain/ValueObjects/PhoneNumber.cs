using Flunt.Validations;
using HelpUp.Shared.ValueObject;
using System.Text.RegularExpressions;
namespace HelpUp.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public PhoneNumber(string number)
    {
        Number = AdjustNumber(number);

        AddNotifications(new Contract<PhoneNumber>()
            .Requires()
            .IsNotNullOrEmpty(Number, "PhoneNumber.Number", "Número de contato não pode estar vazio"));

        if (!IsValidNumber(Number)) 
            AddNotification("PhoneNumber.Number", "Número de contato inválido");
    }

    public string Number { get; private set; }

    private string AdjustNumber(string number)
    {
        var digitsOnly = Regex.Replace(number, @"[^\d]", "");
        if (digitsOnly.Length == 10) digitsOnly = digitsOnly.Insert(2, "9");
        return Regex.Replace(digitsOnly, @"(\d{2})(\d{5})(\d{4})", "($1) $2-$3");
    }

    private bool IsValidNumber(string number) => Regex.IsMatch(number, @"^\(\d{2}\) \d{5}-\d{4}$");

    public override string ToString() => Number;
}