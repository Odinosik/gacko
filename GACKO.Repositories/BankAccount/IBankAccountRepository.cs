using GACKO.Shared.Models.BankAccount;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO.Repositories.BankAccount
{
    public interface IBankAccountRepository
    {
        /// <summary>
        /// Create new Bankaccount
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Create(BankAccountForm form);
        /// <summary>
        /// Get BankAccount by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BankAccountModel> Get(int id);
        /// <summary>
        /// Get All BankAccounts by UserId
        /// </summary>
        /// <returns></returns>
        Task<IList<BankAccountModel>> GetAll(int id);
        /// <summary>
        /// Update BankAccount
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Update(BankAccountForm form);
        /// <summary>
        /// Delete BankAccount
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Delete(int id);
    }
}
