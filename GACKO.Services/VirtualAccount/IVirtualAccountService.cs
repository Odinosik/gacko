using GACKO.Shared.Models.VirtualAccount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GACKO.Services.VirtualAccount
{
    public interface IVirtualAccountService
    {
        Task<int> Create(VirtualAccountForm form);
        Task<VirtualAccountModel> Get(int id);
        Task<IList<VirtualAccountModel>> GetAll(int bankAccountId);
        Task<int> Update(VirtualAccountForm form);
        Task<int> Delete(int id);
    }
}
