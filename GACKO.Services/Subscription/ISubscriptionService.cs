using GACKO.Shared.Models.Subscription;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO.Services.Subscription
{
    public interface ISubscriptionService
    {
        /// <summary>
        /// Create new Subscription
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Create(SubscriptionForm form);
        /// <summary>
        /// Get Subscription by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SubscriptionModel> Get(int id);
        /// <summary>
        /// Get all Subscription by VirtualAccountId
        /// </summary>
        /// <param name="virtualAccountId"></param>
        /// <returns></returns>
        Task<IList<SubscriptionModel>> GetAll(int virtualAccountId);
        /// <summary>
        /// Update Subscription
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Update(SubscriptionForm form);
        /// <summary>
        /// Delete Subscription by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Delete(int id);
    }
}
