using Flunt.Validations;
using HelpUp.Shared.ValueObject;

namespace HelpUp.Domain.ValueObjects;

public class Money : ValueObject
{
    public Money(decimal amount)
    {
        Amount = amount;

        AddNotifications(new Contract<Money>()
            .Requires()
            .IsGreaterThan(Amount, 0, "Money.Amount", "O valor deve ser maior que zero."));
    }

    public decimal Amount { get; private set; }

    public override string ToString() => Amount.ToString();
}