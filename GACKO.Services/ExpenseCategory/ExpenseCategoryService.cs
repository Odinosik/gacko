using GACKO.Repositories.ExpenseCategory;
using GACKO.Shared.Models.ExpenseCategory;
using GACKO.Shared.Models.Subscription;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO.Services.ExpenseCategory
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository _expensecategoryRepository;

        public ExpenseCategoryService(IExpenseCategoryRepository expenseCategoryRepository)
        {
            _expensecategoryRepository = expenseCategoryRepository;
        }

        public Task<int> Create(ExpenseCategoryForm form)
        {
            return _expensecategoryRepository.Create(form);
        }

        public Task<ExpenseCategoryModel> Get(int id)
        {
            return _expensecategoryRepository.Get(id);
        }

        public Task<IList<ExpenseCategoryModel>> GetAll()
        {
            return _expensecategoryRepository.GetAll();
        }

        public Task<int> Update(ExpenseCategoryForm form)
        {
            return _expensecategoryRepository.Update(form);
        }

        public Task<int> Delete(int id)
        {
            return _expensecategoryRepository.Delete(id);
        }
    }
}
