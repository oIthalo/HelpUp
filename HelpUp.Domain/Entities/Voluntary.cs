using HelpUp.Domain.ValueObjects;
using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class Voluntary : Entity
{
    public Voluntary(PersonName name, Email email, PhoneNumber phoneNumber, IList<ONG> oNGS)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        ONGS = new List<ONG>();
    }

    public PersonName Name { get; private set; }
    public Email Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public IReadOnlyCollection<ONG> ONGS { get; private set; }
}