using HelpUp.Domain.ValueObjects;
namespace HelpUp.Tests.ValueObjects;

[TestClass]
public class AddressTests
{
    [TestMethod]
    [DataTestMethod]
    [DataRow("789", "BA", "City", "Bairro", "Rua do Teste", 999, "References")]
    [DataRow("1234567", "BA", "City", "Bairro", "Rua do Teste", 999, "References")]
    [DataRow("659.052.534", "BA", "City", "Bairro", "Rua do Teste", 999, "References")]
    public void Deve_Retornar_Erro_Quando_Cep_For_Invalido(string cep, string estado, string cidade, string bairro, string rua, int numero, string referencias)
    {
        var address = new Address(cep, estado, cidade, bairro, rua, numero, referencias);
        Assert.AreEqual(false, address.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("65905253", "BA", "City", "Bairro", "Rua do Teste", 999, "References")]
    [DataRow("659-05253", "BA", "City", "Bairro", "Rua do Teste", 999, "References")]
    [DataRow("65.905-253", "BA", "City", "Bairro", "Rua do Teste", 999, "References")]
    public void Deve_Retornar_Sucesso_Quando_Cep_For_Valido(string cep, string estado, string cidade, string bairro, string rua, int numero, string referencias)
    {
        var address = new Address(cep, estado, cidade, bairro, rua, numero, referencias);
        Assert.IsTrue(address.IsValid);
    }
}
