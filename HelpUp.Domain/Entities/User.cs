using HelpUp.Domain.ValueObjects;
using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class User : Entity
{
    private readonly IList<Donation> _donations;

    public User(PersonName name, Email email, string password, PhoneNumber phoneNumber, Address address)
    {
        Name = name;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Address = address;
        _donations = new List<Donation>();
    }

    public PersonName Name { get; private set; }
    public Email Email { get; private set; }
    public string Password { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<Donation> Donations => _donations.ToArray();

    public override string ToString()
    {
        return $"{Name}";
    }
}