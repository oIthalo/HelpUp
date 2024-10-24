using HelpUp.Domain.ValueObjects;
namespace HelpUp.Tests.ValueObjects;

[TestClass]
public class PhoneNumberTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenNumberIsInvalid()
    {
        var nmb = new PhoneNumber("81234");
        Assert.IsFalse(nmb.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenNumberIsValid()
    {
        var nmb = new PhoneNumber("75991302860");
        Assert.IsTrue(nmb.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenNumberIsMissing9AndAddedAutomatically()
    {
        var nmb = new PhoneNumber("7591302860");
        Assert.IsTrue(nmb.IsValid);
    }

    [TestMethod]
    public void ShouldFormatNumberCorrectly()
    {
        var nmb = new PhoneNumber("75991302860");
        Assert.AreEqual("(75) 99130-2860", nmb.ToString());
    }
}