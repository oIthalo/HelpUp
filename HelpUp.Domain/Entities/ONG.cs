using Flunt.Validations;
using HelpUp.Domain.ValueObjects;
using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class ONG : Entity
{
    private readonly IList<Campaign> _campaigns;

    public ONG(SingleName name, Description description, Document cNPJ, CEP cEP, Address address, FoundationDate foundationDate, PhoneNumber contactNumber, Email email, Category category, FullName founder)
    {
        Name = name;
        Description = description;
        CNPJ = cNPJ;
        CEP = cEP;
        Address = address;
        FoundationDate = foundationDate;
        ContactNumber = contactNumber;
        Email = email;
        Category = category;
        Founder = founder;
        _campaigns = new List<Campaign>();

        AddNotifications(name, description, cNPJ, cEP, address, foundationDate, contactNumber, email, category, founder, new Contract<ONG>()
                .IsLowerOrEqualsThan(_campaigns.Count(c => c.IsActive), 5, "ONG.Campaigns", "Uma ONG pode ter no máximo 5 campanhas ativas."));
    }

    public SingleName Name { get; private set; }
    public Description Description { get; private set; }
    public Document CNPJ { get; private set; }
    public CEP CEP { get; private set; }
    public Address Address { get; private set; }
    public FoundationDate FoundationDate { get; private set; }
    public PhoneNumber ContactNumber { get; private set; }
    public Email Email { get; private set; }
    public Category Category { get; private set; }
    public FullName Founder { get; private set; }
    public IReadOnlyCollection<Campaign> Campaigns => _campaigns.ToArray();

    private void CreateCampaign(Campaign campaign)
    {
        if (campaign == null)
        {
            AddNotification("ONG.Campaign", "A campanha não pode ser nula.");
            return;
        }

        var campaignsActives = _campaigns.Where(x => x.IsActive == true);

        if (campaignsActives.Count() >= 5)
        {
            AddNotification("ONGS.Campaigns", "Uma ONG pode ter no máximo 5 campanhas ativas");
            return;
        }

        _campaigns.Add(campaign);
    }

    public override string ToString() => Name.ToString();
}