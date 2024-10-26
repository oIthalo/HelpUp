using Flunt.Validations;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class Password : ValueObject
{
    public Password(string passwordHash, string rePasswordHas)
    {
        PasswordHash = passwordHash;
        RePasswordHash = rePasswordHas;

        AddNotifications(new Contract<Password>()
                .Requires()
                .IsNotNullOrEmpty(PasswordHash, "Password.PasswordHash", "A senha não pode ser nula ou vazia.")
                .IsNotNullOrEmpty(RePasswordHash, "Password.RePasswordHash", "A confirmação da senha não pode ser nula ou vazia.")
                .AreEquals(PasswordHash, RePasswordHash, "Password.RePasswordHash", "As senhas devem ser iguais."));
    }

    public string PasswordHash { get; private set; }
    public string RePasswordHash { get; private set; }

    public override string ToString() => PasswordHash;
}