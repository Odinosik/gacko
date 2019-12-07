using GACKO.Shared.Models.Subscription;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO.Services.Subscription
{
    public interface ISubscriptionService
    {
        Task<int> Create(SubscriptionForm form);
        Task<SubscriptionModel> Get(int id);
        Task<IList<SubscriptionModel>> GetAll(int virtualAccountId);
        Task<int> Update(SubscriptionForm form);
        Task<int> Delete(int id);
    }
}
