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

        public Task<int> Create(BankAccountForm form)
        {
            form.UserId = UserContext.UserId;
            return _bankAccountRepository.Create(form);
        }

        public Task<BankAccountModel> Get(int id)
        {
            return _bankAccountRepository.Get(id);
        }

        public Task<IList<BankAccountModel>> GetAll()
        {
            return _bankAccountRepository.GetAll(UserContext.UserId);
        }

        public Task<int> Update(BankAccountForm form)
        {
            form.UserId = UserContext.UserId;
            return _bankAccountRepository.Update(form);
        }

        public Task<int> Delete(int id)
        {
            return _bankAccountRepository.Delete(id);
        }
    }
}
