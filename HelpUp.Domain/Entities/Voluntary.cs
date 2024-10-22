using HelpUp.Domain.ValueObjects;
using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class Voluntary : Entity
{
    public Voluntary(Name name, Email email, PhoneNumber phoneNumber, List<ONG> oNGS)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        ONGS = new List<ONG>();
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public List<ONG> ONGS { get; private set; }
}