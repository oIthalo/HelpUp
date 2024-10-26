using Flunt.Validations;
using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class FoundationDate : ValueObject
{
    public FoundationDate(DateTime date)
    {
        Date = date;

        AddNotifications(new Contract<FoundationDate>()
            .Requires()
            .IsLowerOrEqualsThan(Date, DateTime.Now, "FoundationDate.Date", "A data de fundação não pode ser uma data futura."));
    }

    public DateTime Date { get; private set; }

    public override string ToString() => Date.ToString("dd/MM/yyyy");
}
