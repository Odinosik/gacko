using GACKO.Shared.Models.VirtualAccount;
using System;

namespace GACKO.Shared.Models.Subscription
{
    public class SubscriptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double  Amount { get; set; }
        public DateTime? Date { get; set; }
        public int VirtualAccountId { get; set; }
        public VirtualAccountModel VirtualAccount { get; set; }
    }
}
