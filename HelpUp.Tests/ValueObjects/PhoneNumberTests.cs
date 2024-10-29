using HelpUp.Domain.ValueObjects;
namespace HelpUp.Tests.ValueObjects;

[TestClass]
public class PhoneNumberTests
{
    [TestMethod]
    [DataTestMethod]
    [DataRow("")]
    [DataRow("999876543210")]
    [DataRow("999876543")]
    public void Deveria_Retornar_Erro_Se_O_Numero_For_Invalido(string number)
    {
        var nmb = new PhoneNumber(number);
        Assert.AreEqual(false, nmb.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("(94) 98181-3834")]
    [DataRow("7998853-4923")]
    [DataRow("(61) 8495-7182")]
    [DataRow("5496834-6042")]
    public void Deveria_Retornar_Sucesso_Se_O_Numero_For_Valido(string number)
    {
        var nmb = new PhoneNumber(number);
        Assert.AreEqual(true, nmb.IsValid);
    }
    
    [TestMethod]
    [DataTestMethod]
    [DataRow("(83) 99675-3593")]
    [DataRow("(83) 9675-3593")]
    [DataRow("83 996753593")]
    [DataRow("83 96753593")]
    [DataRow("8396753593")]
    [DataRow("83996753593")]
    public void Deveria_Retornar_Sucesso_Se_Os_Numeros_Forem_Iguais(string number)
    {
        var nmb = new PhoneNumber(number);
        Assert.AreEqual(true, nmb.IsValid);
    }
}