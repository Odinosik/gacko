using System;

namespace GACKO.Shared.Models.Subscription
{
    public class SubscriptionForm
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime? Date { get; set; }
        public int VirtualAccountId { get; set; }
    }
}
