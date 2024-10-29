using HelpUp.Domain.Entities;
using HelpUp.Domain.Enums;
using HelpUp.Domain.ValueObjects;
namespace HelpUp.Tests.Entities;

[TestClass]
public class ONGTests
{
    // ONG datas
    private readonly Name _name = new Name("Instituto Esperança");
    private readonly Description _description = new Description("ONG focada em educação e apoio social.");
    private readonly Document _document = new Document(EDocumentType.CNPJ, "59.114.484/0001-42");
    private readonly Address _address = new Address("12345678", "SP", "São Paulo", "Centro", "Rua da paz", 123, "Próximo à praça central");
    private readonly FoundationDate _foundationDate = new FoundationDate(new DateTime(2010, 5, 15));
    private readonly PhoneNumber _contactNumber = new PhoneNumber("(11) 98765-4321");
    private readonly Email _email = new Email("contato@institutoesperanca.org");
    private readonly Category _category = new Category("Educação e Apoio Social");
    private readonly Name _founder = new Name("Maria Silva");

    // Campaign datas
    private readonly Name _campaignName = new Name("Campanha Contra a Fome");
    private readonly Description _campaignDescription = new Description("Campanha para arrecadar fundos para combate à fome em regiões carentes.");
    private readonly DateRange _campaignDates = new DateRange(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31));
    private readonly Money _fundraisingGoal = new Money(100000);

    [TestMethod]
    public void Deveria_Retornar_Sucesso_Se_A_ONG_For_Criada()
    {
        var ong = new ONG(_name, _description, _document, _address, _foundationDate, _contactNumber, _email, _category, _founder);
        Assert.AreEqual(true, ong.IsValid);
    }

    [TestMethod]
    public void Deveria_Retornar_Sucesso_Se_A_ONG_Estiver_Com_Os_Dados_Corretos()
    {
        var ong = new ONG(_name, _description, _document, _address, _foundationDate, _contactNumber, _email, _category, _founder);

        Assert.AreEqual(_name, ong.Name);
        Assert.AreEqual(_description, ong.Description);
        Assert.AreEqual(_document, ong.CNPJ);
        Assert.AreEqual(_address, ong.Address);
        Assert.AreEqual(_foundationDate, ong.FoundationDate);
        Assert.AreEqual(_contactNumber, ong.ContactNumber);
        Assert.AreEqual(_email, ong.Email);
        Assert.AreEqual(_category, ong.Category);
        Assert.AreEqual(_founder, ong.Founder);
    }

    [TestMethod]
    public void Deveria_Retornar_Sucesso_Se_A_Campanha_For_Criada()
    {
        var ong = new ONG(_name, _description, _document, _address, _foundationDate, _contactNumber, _email, _category, _founder);
        var campaign = new Campaign(_campaignName, _campaignDescription, _campaignDates, _fundraisingGoal);

        ong.CreateCampaign(campaign);

        Assert.AreEqual(1, ong.Campaigns.Count);
        Assert.AreSame(campaign, ong.Campaigns.First());
    }
}