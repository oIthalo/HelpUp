using HelpUp.Domain.ValueObjects;
using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class ONG : Entity
{
    private readonly IList<Campaign> _campaigns;

    public ONG(EntityName name, Description description, string cNPJ, string cEP, Address address, string foundationDate, PhoneNumber contactNumber, Email email, string category, string founder)
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
    }

    public EntityName Name { get; private set; }
    public Description Description { get; private set; }
    public string CNPJ { get; private set; }
    public string CEP { get; private set; }
    public Address Address { get; private set; }
    public string FoundationDate { get; private set; }
    public PhoneNumber ContactNumber { get; private set; }
    public Email Email { get; private set; }
    public string Category { get; private set; }
    public string Founder { get; private set; }
    public IReadOnlyCollection<Campaign> Campaigns => _campaigns.ToArray();

    public override string ToString()
    {
        return $"{Name}";
    }
}