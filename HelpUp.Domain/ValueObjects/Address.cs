using Flunt.Validations;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string cep, string state, string city, string neighborhood, string street, int number, string? references)
    {
        CEP = AdjustCep(cep);
        State = state;
        City = city;
        Neighborhood = neighborhood;
        Street = street;
        Number = number;
        References = references;

        AddNotifications(new Contract<Address>()
            .Requires()
            .IsNotNullOrEmpty(City, "Address.City", "A cidade não pode ser vazia")
            .IsNotNullOrEmpty(Street, "Address.Street", "A rua não pode ser vazia")
            .IsNotNullOrEmpty(Neighborhood, "Address.Neighborhood", "O bairro não pode estar vazio")
            .IsNotNullOrEmpty(State, "Address.State", "O estado não pode estar vazio")
            .IsGreaterThan(Number, 0, "Address.Number", "O número residencial não pode ser negativo")
            .IsTrue(IsValidCep(CEP), "Address.CEP", "CEP inválido"));
    }

    public string CEP { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Neighborhood { get; private set; }
    public string Street { get; private set; }
    public int Number { get; private set; }
    public string? References { get; private set; }

    private string AdjustCep(string cep) => new string(cep.Where(char.IsDigit).ToArray());

    private bool IsValidCep(string cep)
    {
        var contract = new Contract<Address>()
            .Requires()
            .IsNotNullOrEmpty(cep, "Address.CEP", "O CEP não pode ser vazio")
            .IsTrue(cep.Length == 8, "Address.CEP", "O CEP deve ter exatamente 8 caracteres");

        AddNotifications(contract);
        return contract.IsValid;
    }

    public override string ToString()
    {
        return $"{Street}, {Number}, {Neighborhood}, {City}/{State}" +
               $"{(References != null ? $" (Referências: {References})" : "")}";
    }
}