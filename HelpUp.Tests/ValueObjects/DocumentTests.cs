using HelpUp.Domain.Enums;
using HelpUp.Domain.ValueObjects;
namespace HelpUp.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{

    [TestMethod]
    [DataTestMethod]
    [DataRow("509.042.510-81")]    
    [DataRow("111.111.111-11")]    
    [DataRow("5090425108")]        
    [DataRow("")]                  
    public void Deve_Retornar_Erro_Quando_Documento_For_Um_CPF_Invalido(string validCpf)
    {
        var cpf = new Document(EDocumentType.CPF, validCpf);
        Assert.AreEqual(false, cpf.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("509.042.510-80")]    
    [DataRow("50904251080")]        
    public void Deve_Retornar_Sucesso_Quando_Documento_For_Um_CPF_Valido(string cpfValido)
    {
        var cpf = new Document(EDocumentType.CPF, cpfValido);
        Assert.AreEqual(true, cpf.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("44.877.443/0001-30")]
    [DataRow("44877443000130")]
    public void Deve_Retornar_Sucesso_Quando_Documento_For_Um_CNPJ_Valido(string validCpnj)
    {
        var cnpj = new Document(EDocumentType.CNPJ, validCpnj);
        Assert.AreEqual(true, cnpj.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("")]                      
    [DataRow("42.006.421/0001-81")]    
    [DataRow("11.111.111/1111-11")]    
    [DataRow("4200642100018")]         
    public void Deve_Retornar_Erro_Quando_Documento_For_Um_CNPJ_Invalido(string invalidCpnj)
    {
        var cnpj = new Document(EDocumentType.CNPJ, invalidCpnj);
        Assert.AreEqual(false, cnpj.IsValid);
    }
}