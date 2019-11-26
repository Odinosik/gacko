using GACKO.Repositories.VirtualAccount;
using GACKO.Shared.Models.VirtualAccount;
using System.Threading.Tasks;

namespace GACKO.Services.VirtualAccount
{
    public class VirtualAccountService : IVirtualAccountService
    {
        private readonly IVirtualAccountRepository _virtualAccountRepository;

        public VirtualAccountService(IVirtualAccountRepository virtualAccountRepository)
        {
            _virtualAccountRepository = virtualAccountRepository;
        }

        public Task<int> Create(VirtualAccountForm form)
        {
            return _virtualAccountRepository.Create(form);
        }

        public Task<VirtualAccountModel> Get(int id)
        {
            return _virtualAccountRepository.Get(id);
        }

        public Task<int> Update(VirtualAccountForm form)
        {
            return _virtualAccountRepository.Update(form);
        }

        public Task<int> Delete(int id)
        {
            return _virtualAccountRepository.Delete(id);
        }
    }
}
