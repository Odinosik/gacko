using GACKO.Shared.Models.BankAccount;
using System.Threading.Tasks;

namespace GACKO.Services.BankAccount
{
    public interface IBankAccountService
    {
        Task<int> Create(BankAccountForm form);
        Task<BankAccountModel> Get(int id);
        Task<int> Update(BankAccountForm form);
        Task<int> Delete(int id);
    }
}
