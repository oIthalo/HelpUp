using HelpUp.Domain.ValueObjects;
namespace HelpUp.Tests.ValueObjects;

[TestClass]
public class AddressTests
{
    [TestMethod]
    public void ShoudReturnErrorWhenAddressIsInvalid()
    {
        var address = new Address("789", "BA", "City", "Bairro", 999, "References", "State");
        Assert.IsFalse(address.IsValid);
    }

    [TestMethod]
    public void ShoudReturnSuccessWhenAddressIsValid()
    {
        var address = new Address("65905253", "BA", "City", "Bairro", 999, "References", "State");
        Assert.IsTrue(address.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCepHasValidFormat()
    {
        var address = new Address("65905-253", "BA", "City", "Bairro", 999, "References", "State");
        Assert.IsTrue(address.IsValid);
    }
}