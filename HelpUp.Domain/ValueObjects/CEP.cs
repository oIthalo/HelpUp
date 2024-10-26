using Flunt.Validations;
using HelpUp.Shared.ValueObject;
using System.Text.RegularExpressions;
namespace HelpUp.Domain.ValueObjects;

public class CEP : ValueObject
{
    public CEP(string cEPNumber)
    {
        CEPNumber = cEPNumber;

        AddNotifications(new Contract<CEP>()
            .Requires()
            .IsNotNullOrEmpty(cEPNumber, "CEP.CEPNumber", "O CEP não pode estar vazio")
            .IsTrue(ValidateCEP(cEPNumber), "CEP.CEPNumber", "CEP inválido"));
    }

    public string CEPNumber { get; private set; }

    private bool ValidateCEP(string cep)
    {
        cep = Regex.Replace(cep, @"[^\d]", "");

        // CEP deve ter 8 dígitos
        if (cep.Length != 8 || cep.All(c => c == cep[0]))
            return false;

        return true;
    }

    public override string ToString() => $"{CEPNumber}";
}