using HelpUp.Domain.ValueObjects;
using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class ONG : Entity
{
    private readonly IList<Campaign> _campaigns;

    public ONG(Name name, Description description, Document cNPJ, Address address, FoundationDate foundationDate, PhoneNumber contactNumber, Email email, Category category, Name founder)
    {
        Name = name;
        Description = description;
        CNPJ = cNPJ;
        Address = address;
        FoundationDate = foundationDate;
        ContactNumber = contactNumber;
        Email = email;
        Category = category;
        Founder = founder;
        _campaigns = new List<Campaign>();

        AddNotifications(name, description, cNPJ, address, foundationDate, contactNumber, email, category, founder);
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Document CNPJ { get; private set; }
    public Address Address { get; private set; }
    public FoundationDate FoundationDate { get; private set; }
    public PhoneNumber ContactNumber { get; private set; }
    public Email Email { get; private set; }
    public Category Category { get; private set; }
    public Name Founder { get; private set; }
    public IReadOnlyCollection<Campaign> Campaigns => _campaigns.ToArray();

    public void CreateCampaign(Campaign campaign)
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

    public void RemoveCampaign(Guid id)
    {
        var campaign = _campaigns.FirstOrDefault(x => x.Id.Equals(id));

        if (campaign is null)
            AddNotification("Campaign.Campaign", "Campanha não pode ser nula");

        _campaigns.Remove(campaign!);
    }

    public override string ToString() => Name.ToString();
}