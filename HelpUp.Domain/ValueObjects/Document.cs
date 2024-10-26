using Flunt.Validations;
using HelpUp.Domain.Enums;
using HelpUp.Shared.ValueObject;
using System.Text.RegularExpressions;
namespace HelpUp.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(EDocumentType documentType, string documentValue)
    {
        DocumentType = documentType;
        DocumentValue = documentValue;

        AddNotifications(new Contract<Document>()
            .Requires()
            .IsNotNullOrEmpty(documentValue, "Document.DocumentValue", "O valor do documento não pode ser nulo ou vazio")
            .IsTrue(Validate(documentValue, documentType), "Document.DocumentValue", "Documento inválido"));
    }

    public EDocumentType DocumentType { get; private set; }
    public string DocumentValue { get; private set; }

    private bool Validate(string documentValue, EDocumentType documentType)
    {
        switch (documentType)
        {
            case EDocumentType.CPF:
                return CPFValidate(documentValue);
            case EDocumentType.CNPJ:
                return CNPJValidate(documentValue);
            default:
                AddNotification("Document.DocumentValue", "Documento inválido");
                return false;
        }
    }

     bool CPFValidate(string cpf)
    {
        cpf = Regex.Replace(cpf, @"[^\d]", "");

        // CPF deve ter 11 dígitos
        if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
            return false;

        // Cálculo do primeiro dígito verificador
        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (int)(cpf[i] - '0') * (10 - i);
        int primeiroDigito = 11 - (soma % 11);
        primeiroDigito = primeiroDigito > 9 ? 0 : primeiroDigito;

        // Cálculo do segundo dígito verificador
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (int)(cpf[i] - '0') * (11 - i);
        int segundoDigito = 11 - (soma % 11);
        segundoDigito = segundoDigito > 9 ? 0 : segundoDigito;

        return cpf[9] == (char)(primeiroDigito + '0') && cpf[10] == (char)(segundoDigito + '0');
    }

    private bool CNPJValidate(string cnpj)
    {
        cnpj = Regex.Replace(cnpj, @"[^\d]", "");

        // CNPJ deve ter 14 dígitos
        if (cnpj.Length != 14 || cnpj.All(c => c == cnpj[0]))
            return false;

        // Cálculo do primeiro dígito verificador
        int soma = 0;
        int[] pesos = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        for (int i = 0; i < 12; i++)
            soma += (int)(cnpj[i] - '0') * pesos[i % 12];
        int primeiroDigito = 11 - (soma % 11);
        primeiroDigito = primeiroDigito >= 10 ? 0 : primeiroDigito;

        // Cálculo do segundo dígito verificador
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += (int)(cnpj[i] - '0') * pesos[(i + 1) % 12];
        int segundoDigito = 11 - (soma % 11);
        segundoDigito = segundoDigito >= 10 ? 0 : segundoDigito;

        return cnpj[12] == (char)(primeiroDigito + '0') && cnpj[13] == (char)(segundoDigito + '0');
    }

    public override string ToString() => $"{DocumentType}, {DocumentValue}";
}