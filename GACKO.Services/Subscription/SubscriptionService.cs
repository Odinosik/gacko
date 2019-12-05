using GACKO.Repositories.Subscription;
using GACKO.Shared.Models.Subscription;
using System.Threading.Tasks;

namespace GACKO.Services.Subscription
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<int> Create(SubscriptionForm form)
        {
            return _subscriptionRepository.Create(form);
        }

        public Task<SubscriptionModel> Get(int id)
        {
            return _subscriptionRepository.Get(id);
        }

        public Task<int> Update(SubscriptionForm form)
        {
            return _subscriptionRepository.Update(form);
        }

        public Task<int> Delete(int id)
        {
            return _subscriptionRepository.Delete(id);
        }
    }
}
