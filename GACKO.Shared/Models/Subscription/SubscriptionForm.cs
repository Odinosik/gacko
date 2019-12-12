using System;

namespace GACKO.Shared.Models.Subscription
{
    /// <summary>
    /// Create and Update Subscription Form
    /// </summary>
    public class SubscriptionForm
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int FrequncyMonth { get; set; }
        public int VirtualAccountId { get; set; }
    }
}
