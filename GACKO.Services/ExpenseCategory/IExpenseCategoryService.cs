using GACKO.Shared.Models.ExpenseCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO.Services.ExpenseCategory
{
    public interface IExpenseCategoryService
    {
        Task<int> Create(ExpenseCategoryForm form);
        Task<ExpenseCategoryModel> Get(int id);
        Task<IList<ExpenseCategoryModel>> GetAll();
        Task<int> Update(ExpenseCategoryForm form);
        Task<int> Delete(int id);
    }
}