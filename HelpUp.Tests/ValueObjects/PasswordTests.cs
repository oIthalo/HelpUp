using HelpUp.Domain.ValueObjects;
namespace HelpUp.Tests.ValueObjects;

[TestClass]
public class PasswordTests
{
    [TestMethod]
    [DataTestMethod]
    [DataRow("Senha123!", "senha123!")]
    [DataRow("Senha123!", "Senha1234!")]
    [DataRow("12345678", "87654321")]
    [DataRow("Password!", "Password123!")]
    [DataRow("password", "PASSWORD")]
    public void Deveria_Retornar_Erro_Se_As_Senhas_Nao_Forem_Iguais(string password, string rePassword)
    {
        var psswd = new Password(password, rePassword);
        Assert.AreEqual(false, psswd.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("Senha123!", "Senha123!")]
    [DataRow("12345678", "12345678")]
    [DataRow("Password!", "Password!")]
    [DataRow("password", "password")]
    [DataRow("SenhaSegura123#", "SenhaSegura123#")]
    public void Deveria_Retornar_Sucesso_Se_As_Senhas_Forem_Iguais(string password, string rePassword)
    {
        var psswd = new Password(password, rePassword);
        Assert.AreEqual(true, psswd.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow(null, "Senha123!")]
    [DataRow("Senha123!", null)]
    [DataRow("", "Senha123!")]
    [DataRow("Senha123!", "")]
    [DataRow("", "")]
    [DataRow(null, null)]
    public void Deveria_Retornar_Erro_Se_A_Senha_For_Vazia_Ou_Nula(string password, string rePassword)
    {
        var psswd = new Password(password, rePassword);
        Assert.AreEqual(false, psswd.IsValid);
    }

}