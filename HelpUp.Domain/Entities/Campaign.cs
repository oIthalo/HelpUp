using HelpUp.Domain.ValueObjects;
using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class Campaign : Entity
{
    private readonly IList<Donation> _donations;

    public Campaign(Name name, Description description, DateRange dates, Money fundraisingGoal)
    {
        Name = name;
        Description = description;
        DateRanges = dates;
        FundraisingGoal = fundraisingGoal;
        AmountRaised = new Money(0);
        IsActive = true;
        _donations = new List<Donation>();

        AddNotifications(name, description, dates, fundraisingGoal);
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public DateRange DateRanges { get; private set; }
    public Money FundraisingGoal { get; private set; }
    public Money AmountRaised { get; private set; }
    public bool IsActive { get; private set; }
    public IReadOnlyCollection<Donation> Donations => _donations.ToArray();

    public override string ToString() => $"{Name}, {Description}";
}