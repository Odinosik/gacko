using System.Collections.Generic;

namespace GACKO.Shared.Models.Subscription
{
    public class SubscriptionListViewModel
    {
        public int VirtualAccountId { get; set; }
        public virtual IEnumerable<SubscriptionModel> Subscriptions { get; set; }
    }
}
