using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class Campaign : Entity
{
    public Campaign(string name, string description, DateTime startDate, DateTime endDate, decimal fundraisingGoal, decimal amountRaised, List<Donation> donations)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        FundraisingGoal = fundraisingGoal;
        AmountRaised = amountRaised;
        Donations = new List<Donation>();
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal FundraisingGoal { get; private set; }
    public decimal AmountRaised { get; private set; }
    public List<Donation> Donations { get; private set; }
}