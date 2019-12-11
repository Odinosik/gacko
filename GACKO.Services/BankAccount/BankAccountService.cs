using GACKO.Repositories.BankAccount;
using GACKO.Shared;
using GACKO.Shared.Models.BankAccount;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO.Services.BankAccount
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<int> Create(BankAccountForm form)
        {
            form.UserId = UserContext.UserId;
            return await _bankAccountRepository.Create(form);
        }

        public async Task<BankAccountModel> Get(int id)
        {
            return await _bankAccountRepository.Get(id);
        }

        public async Task<IList<BankAccountModel>> GetAll()
        {
            return await _bankAccountRepository.GetAll(UserContext.UserId);
        }

        public async Task<int> Update(BankAccountForm form)
        {
            form.UserId = UserContext.UserId;
            return await _bankAccountRepository.Update(form);
        }

        public async Task<int> Delete(int id)
        {
            return await _bankAccountRepository.Delete(id);
        }
    }
}
