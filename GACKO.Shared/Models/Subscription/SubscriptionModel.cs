using GACKO.Shared.Models.VirtualAccount;
using System;

namespace GACKO.Shared.Models.Subscription
{
    /// <summary>
    /// Subscription Model representing database entity DaoSubscription
    /// </summary>
    public class SubscriptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double  Amount { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int FrequncyMonth { get; set; }
        public int VirtualAccountId { get; set; }
        public VirtualAccountModel VirtualAccount { get; set; }
    }
}
