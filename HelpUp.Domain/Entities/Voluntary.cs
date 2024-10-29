using HelpUp.Domain.ValueObjects;
using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class Voluntary : Entity
{
    private readonly IList<ONG> _ongs;

    public Voluntary(Name name, Email email, PhoneNumber phoneNumber, IList<ONG> oNGS)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        _ongs = new List<ONG>();

        AddNotifications(name, email, phoneNumber);
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public IReadOnlyCollection<ONG> ONGS => _ongs.ToArray();

    public bool AddOng(ONG ong)
    {
        if (_ongs.Count >= 3)
        {
            AddNotification("Voluntary.ONGS", "Um voluntário pode estar ligado a no máximo 3 ONGs.");
            return false;
        }

        if (_ongs.Any(x => x.Email == ong.Email))
        {
            AddNotification("Voluntary.ONGS", "Este voluntário já está associado a esta ONG.");
            return false;
        }

        _ongs.Add(ong);
        return true;
    }

    public override string ToString() => Name.ToString();
}