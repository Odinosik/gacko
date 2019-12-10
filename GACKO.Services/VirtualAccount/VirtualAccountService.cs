using GACKO.Repositories.VirtualAccount;
using GACKO.Shared.Models.VirtualAccount;
using System.Collections.Generic;
using System.Threading.Tasks;
using GACKO.Services.Expense;
using GACKO.Services.Subscription;

namespace GACKO.Services.VirtualAccount
{
    public class VirtualAccountService : IVirtualAccountService
    {
        private readonly IVirtualAccountRepository _virtualAccountRepository;
        private readonly IExpenseService _expenseService;
        private readonly ISubscriptionService _subscriptionService;

        public VirtualAccountService(IVirtualAccountRepository virtualAccountRepository, 
            IExpenseService expenseService,
            ISubscriptionService subscriptionService)
        {
            _virtualAccountRepository = virtualAccountRepository;
            _expenseService = expenseService;
            _subscriptionService = subscriptionService;
        }

        public async Task<int> Create(VirtualAccountForm form)
        {
            return await _virtualAccountRepository.Create(form);
        }

        public async Task<VirtualAccountModel> Get(int id)
        {
            var virtualAcc = await _virtualAccountRepository.Get(id);
            virtualAcc.Expenses = await _expenseService.GetAll(virtualAcc.Id);
            virtualAcc.Subscriptions = await _subscriptionService.GetAll(virtualAcc.Id);
            return virtualAcc;
        }
        public async Task<IList<VirtualAccountModel>> GetAll(int bankAccountId)
        {
            return await _virtualAccountRepository.GetAll(bankAccountId);
        }

        public async Task<int> Update(VirtualAccountForm form)
        {
            return await _virtualAccountRepository.Update(form);
        }

        public async Task<int> Delete(int id)
        {
            return await _virtualAccountRepository.Delete(id);
        }
    }
}
