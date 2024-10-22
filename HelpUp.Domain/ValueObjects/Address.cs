using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string city, string street, string neighborhood, int number, string? references)
    {
        City = city;
        Street = street;
        Neighborhood = neighborhood;
        Number = number;
        References = references;
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