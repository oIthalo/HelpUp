using Flunt.Validations;
using HelpUp.Domain.Enums;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(EDocumentType documentType, string documentValue)
    {
        DocumentType = documentType;
        DocumentValue = RemoveFormatting(documentValue);

        AddNotifications(new Contract<Document>()
            .Requires()
            .IsNotNullOrEmpty(DocumentValue, "Document.DocumentValue", "Documento não pode ser nulo ou vazio")
            .IsTrue(Validate(DocumentValue, documentType), "Document.DocumentValue", "Documento inválido"));
    }

    public EDocumentType DocumentType { get; private set; }
    public string DocumentValue { get; private set; }

    private string RemoveFormatting(string document)
    {
        return new string(document.Where(char.IsDigit).ToArray());
    }

    private bool Validate(string documentValue, EDocumentType documentType)
    {
        return documentType switch
        {
            EDocumentType.CPF => ValidateCPF(documentValue),
            EDocumentType.CNPJ => ValidateCNPJ(documentValue),
            _ => false
        };
    }

    private bool ValidateCPF(string cpf)
    {
        if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
            return false;

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += (cpf[i] - '0') * (10 - i);

        int firstDigit = 11 - (sum % 11);
        firstDigit = firstDigit > 9 ? 0 : firstDigit;

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += (cpf[i] - '0') * (11 - i);

        int secondDigit = 11 - (sum % 11);
        secondDigit = secondDigit > 9 ? 0 : secondDigit;

        return cpf[9] == (char)(firstDigit + '0') && cpf[10] == (char)(secondDigit + '0');
    }

    private bool ValidateCNPJ(string cnpj)
    {
        if (cnpj.Length != 14 || cnpj.All(c => c == cnpj[0]))
            return false;

        int[] weightsFirst = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int sum = 0;

        for (int i = 0; i < 12; i++)
            sum += (cnpj[i] - '0') * weightsFirst[i];

        int firstDigit = 11 - (sum % 11);
        firstDigit = firstDigit >= 10 ? 0 : firstDigit;

        if (cnpj[12] != (char)(firstDigit + '0'))
            return false;

        int[] weightsSecond = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        sum = 0;

        for (int i = 0; i < 13; i++)
            sum += (cnpj[i] - '0') * weightsSecond[i];

        int secondDigit = 11 - (sum % 11);
        secondDigit = secondDigit >= 10 ? 0 : secondDigit;

        return cnpj[13] == (char)(secondDigit + '0');
    }

    public override string ToString() => $"{DocumentType}, {DocumentValue}";
}