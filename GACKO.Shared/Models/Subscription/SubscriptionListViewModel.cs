using System.Collections.Generic;

namespace GACKO.Shared.Models.Subscription
{
    /// <summary>
    /// Subscription List View Model
    /// </summary>
    public class SubscriptionListViewModel : GackoBaseViewModel
    {
        public int VirtualAccountId { get; set; }
        public virtual IEnumerable<SubscriptionModel> Subscriptions { get; set; }
    }
}
