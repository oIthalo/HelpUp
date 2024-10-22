using HelpUp.Domain.ValueObjects;
using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class Campaign : Entity
{
    private readonly IList<Donation> _donations;

    public Campaign(EntityName name, Description description, DateTime startDate, DateTime endDate, decimal fundraisingGoal, decimal amountRaised)
    {
        Name = name;
        Description = description;
        StartDate = DateTime.Now;
        EndDate = endDate;
        FundraisingGoal = fundraisingGoal;
        AmountRaised = amountRaised;
        _donations = new List<Donation>();
    }

    public EntityName Name { get; private set; }
    public Description Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal FundraisingGoal { get; private set; }
    public decimal AmountRaised { get; private set; }
    public IReadOnlyCollection<Donation> Donations => _donations.ToArray();

    public override string ToString()
    {
        return $"{Name}, {Description}";
    }
}