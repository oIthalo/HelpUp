using HelpUp.Domain.ValueObjects;
namespace HelpUp.Tests.ValueObjects;

[TestClass]
public class AddressTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenAddressIsInvalid()
    {
        var address = new Address("789", "BA", "City", "Bairro", "Rua do Teste", 999, "References");
        Assert.IsFalse(address.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddressIsValid()
    {
        var address = new Address("65905253", "BA", "City", "Bairro", "Rua do Teste", 999, "References");
        Assert.IsTrue(address.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCepHasValidFormat()
    {
        var address = new Address("65905253", "BA", "City", "Bairro", "Rua do Teste", 999, "References");
        Assert.IsTrue(address.IsValid);
    }
}
