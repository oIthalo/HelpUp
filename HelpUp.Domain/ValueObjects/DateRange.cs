using Flunt.Validations;
using HelpUp.Shared.ValueObject;

namespace HelpUp.Domain.ValueObjects;

public class DateRange : ValueObject
{
    public DateRange(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;

        AddNotifications(new Contract<DateRange>()
            .Requires()
            .IsLowerOrEqualsThan(StartDate, EndDate, "DateRange", "A data de início deve ser anterior ou igual à data de término."));
    }

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public override string ToString() => $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
}