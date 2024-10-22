using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class Voluntary : Entity
{
    public Voluntary(string name, string email, string phoneNumber, List<ONG> oNGS)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        ONGS = new List<ONG>();
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public List<ONG> ONGS { get; private set; }
}