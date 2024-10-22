using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class Donation : Entity
{
    public Donation(decimal amount, DateTime donationDate, string paymentMethod)
    {
        Amount = amount;
        DonationDate = donationDate;
        PaymentMethod = paymentMethod;
    }

    public decimal Amount { get; private set; }
    public DateTime DonationDate { get; private set; }
    // choise to enum
    public string PaymentMethod { get; private set; }
}