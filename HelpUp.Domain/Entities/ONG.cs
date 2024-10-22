using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class ONG : Entity
{
    public ONG(string name, string description, string cNPJ, string cEP, string address, string foundationDate, string contactNumber, string email, string category, string founder, List<Campaign> campaigns)
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
        Campaigns = new List<Campaign>();
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public string CNPJ { get; private set; }
    public string CEP { get; private set; }
    public string Address { get; private set; }
    public string FoundationDate { get; private set; }
    public string ContactNumber { get; private set; }
    public string Email { get; private set; }
    public string Category { get; private set; }
    public string Founder { get; private set; }
    public List<Campaign> Campaigns { get; private set; }
}