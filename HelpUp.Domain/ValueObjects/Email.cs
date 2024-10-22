using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class Email : ValueObject
{
    public Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public string EmailAddress { get; private set; }
}