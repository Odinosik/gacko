using GACKO.Shared.Models.Subscription;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO.Repositories.Subscription
{
    public interface ISubscriptionRepository
    {
        Task<int> Create(SubscriptionForm form);
        Task<SubscriptionModel> Get(int id);
        Task<IList<SubscriptionModel>> GetAll(int virtualAccountId);
        Task<int> Update(SubscriptionForm form);
        Task<int> Delete(int id);
    }
}
