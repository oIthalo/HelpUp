using Flunt.Validations;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string city, string street, string neighborhood, int number, string? references, string state)
    {
        City = city;
        Street = street;
        Neighborhood = neighborhood;
        Number = number;
        References = references;
        State = state;

        AddNotifications(new Contract<Address>()
            .Requires()
            .IsNotNullOrEmpty(City, "Address.City", "A cidade não pode ser vazia")
            .IsNotNullOrEmpty(Street, "Address.Street", "A rua não pode ser vazia")
            .IsNotNullOrEmpty(Neighborhood, "Address.Neighborhood", "O bairro não pode estar vazio")
            .IsNotNullOrEmpty(State, "Address.State", "O estado não pode estar vazio")
            .IsGreaterThan(Number, 0, "Address.Number", "O número residencial não pode ser negativo"));
    }

    public string City { get; private set; }
    public string State { get; private set; }
    public string Street { get; private set; }
    public string Neighborhood { get; private set; }
    public int Number { get; private set; }
    public string? References { get; private set; }

    public override string ToString()
    {
        return $"{Street}, {Number}, {Neighborhood}, {City}/{State}" +
               $"{(References != null ? $" (Referências: {References})" : "")}";
    }
}