using HelpUp.Domain.Enums;
using HelpUp.Shared.Entities;
namespace HelpUp.Domain.Entities;

public class Donation : Entity
{
    public Donation(decimal amount, DateTime donationDate, EPaymentMethod paymentMethod)
    {
        Amount = amount;
        DonationDate = DateTime.Now;
        PaymentMethod = paymentMethod;
    }

    public decimal Amount { get; private set; }
    public DateTime DonationDate { get; private set; }
    public EPaymentMethod PaymentMethod { get; private set; }
}