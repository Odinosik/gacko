using GACKO.Repositories.Expense;
using GACKO.Shared.Models.Expense;
using System.Collections.Generic;
using System.Threading.Tasks;
using GACKO.Repositories.SalesDocument;

namespace GACKO.Services.Expense
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ISalesDocumentRepository _salesDocumentRepository;

        public ExpenseService(IExpenseRepository expenseRepository, ISalesDocumentRepository salesDocumentRepository)
        {
            _expenseRepository = expenseRepository;
            _salesDocumentRepository = salesDocumentRepository;
        }

        public async Task<int> Create(ExpenseForm form)
        {
            return await _expenseRepository.Create(form);
        }

        public async Task<ExpenseModel> Get(int id)
        {
            return await _expenseRepository.Get(id);
        }
        public async Task<IList<ExpenseModel>> GetAll(int virtualAccountId)
        {
            var expenses = await _expenseRepository.GetAll(virtualAccountId);
            foreach (var expenseModel in expenses)
            {
                expenseModel.SalesDocuments = await _salesDocumentRepository.GetAll();
            }
            return ;
        }
        public async Task<int> Update(ExpenseForm form)
        {
            return await _expenseRepository.Update(form);
        }

        public async Task<int> Delete(int id)
        {
            return await _expenseRepository.Delete(id);
        }
    }
}
