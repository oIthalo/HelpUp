using HelpUp.Domain.Entities;
using HelpUp.Domain.ValueObjects;
namespace HelpUp.Tests.Entities;

[TestClass]
public class UserTests
{
    private readonly Name _name = new Name("Bob Smith");
    private readonly Email _email = new Email("bob@mail.com");
    private readonly Password _password = new Password("Senha123!", "Senha123!");
    private readonly PhoneNumber _phoneNumber = new PhoneNumber("(11) 8765-4321");
    private readonly Address _address = new Address("12345-678", "SP", "São Paulo", "Centro", "Rua da paz", 123, "Próximo à praça central");

    [TestMethod]
    public void Deveria_Retornar_Sucesso_Se_O_Usuario_For_Criado()
    {
        var user = new User(_name, _email, _password, _phoneNumber, _address);
        Assert.AreEqual(true, user.IsValid);
    }

    [TestMethod]
    public void Deveria_Retornar_Sucesso_Se_Os_Dados_Estiverem_Corretos()
    {
        var user = new User(_name, _email, _password, _phoneNumber, _address);
        Assert.AreEqual(_name, user.Name);
        Assert.AreEqual(_email, user.Email);
        Assert.AreEqual(_password, user.Password);
        Assert.AreEqual(_phoneNumber, user.PhoneNumber);
        Assert.AreEqual(_address, user.Address);
    }
}