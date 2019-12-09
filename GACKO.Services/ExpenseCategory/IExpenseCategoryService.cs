using GACKO.Shared.Models.ExpenseCategory;
using System.Threading.Tasks;

namespace GACKO.Services.ExpenseCategory
{
    public interface IExpenseCategoryService
    {
        /// <summary>
        /// Create new ExpenseCategory
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Create(ExpenseCategoryForm form);
        /// <summary>
        /// Get ExpenseCategory by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ExpenseCategoryModel> Get(int id);
        /// <summary>
        /// Update ExpenseCategory
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Update(ExpenseCategoryForm form);
        /// <summary>
        /// Delete ExpenseCategory by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Delete(int id);
    }
}