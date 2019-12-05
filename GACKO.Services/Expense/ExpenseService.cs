using GACKO.Repositories.Expense;
using GACKO.Shared.Models.Expense;
using System.Threading.Tasks;

namespace GACKO.Services.Expense
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public Task<int> Create(ExpenseForm form)
        {
            return _expenseRepository.Create(form);
        }

        public Task<ExpenseModel> Get(int id)
        {
            return _expenseRepository.Get(id);
        }

        public Task<int> Update(ExpenseForm form)
        {
            return _expenseRepository.Update(form);
        }

        public Task<int> Delete(int id)
        {
            return _expenseRepository.Delete(id);
        }
    }
}
