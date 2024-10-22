using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class User : Entity
{
    public User(string name, string email, string password, string phoneNumber, string address, List<Donation> donations)
    {
        Name = name;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Address = address;
        Donations = new List<Donation>();
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public List<Donation> Donations { get; private set; }
}