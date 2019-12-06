using GACKO.Shared.Models.Subscription;
using System.Threading.Tasks;

namespace GACKO.Repositories.Subscription
{
    public interface ISubscriptionRepository
    {
        Task<int> Create(SubscriptionForm form);
        Task<SubscriptionModel> Get(int id);
        Task<int> Update(SubscriptionForm form);
        Task<int> Delete(int id);
    }
}
