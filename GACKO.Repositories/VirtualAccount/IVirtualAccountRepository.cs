using GACKO.Shared.Models.VirtualAccount;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO.Repositories.VirtualAccount
{
    public interface IVirtualAccountRepository
    {
        /// <summary>
        /// Create new VirtualAccount
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Create(VirtualAccountForm form);
        /// <summary>
        /// Get VirtualAccount by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<VirtualAccountModel> Get(int id);
        /// <summary>
        /// Get all VirtualAccounts by BankAccountId
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <returns></returns>
        Task<IList<VirtualAccountModel>> GetAll(int bankAccountId);
        /// <summary>
        /// Update VirtualAccount
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Update(VirtualAccountForm form);
        /// <summary>
        /// Delete VirtualAccount by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Delete(int id);
    }
}
