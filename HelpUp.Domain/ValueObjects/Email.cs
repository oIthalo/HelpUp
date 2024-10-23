using Flunt.Validations;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class Email : ValueObject
{
    public Email(string emailAddress)
    {
        EmailAddress = emailAddress;

        AddNotifications(new Contract<Email>()
            .Requires()
            .IsNotNullOrEmpty(EmailAddress, "Email.EmailAddress", "Email não pode estar vazio")
            .IsEmail(EmailAddress, "Email.EmailAddress", "Email inválido"));
    }

    public string EmailAddress { get; private set; }

    public override string ToString()
    {
        return EmailAddress;
    }
}