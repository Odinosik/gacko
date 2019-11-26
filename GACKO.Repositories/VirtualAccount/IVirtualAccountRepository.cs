using GACKO.Shared.Models.VirtualAccount;
using System.Threading.Tasks;

namespace GACKO.Repositories.VirtualAccount
{
    public interface IVirtualAccountRepository
    {
        Task<int> Create(VirtualAccountForm form);
        Task<VirtualAccountModel> Get(int id);
        Task<int> Update(VirtualAccountForm form);
        Task<int> Delete(int id);
    }
}
