using GACKO.Shared.Models.Expense;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO.Repositories.Expense
{
    public interface IExpenseRepository
    {
        /// <summary>
        /// Create new Expense
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Create(ExpenseForm form);
        /// <summary>
        /// Get Expense by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ExpenseModel> Get(int id);
        /// <summary>
        /// Get All Expense by VirtualAccountId
        /// </summary>
        /// <param name="virtualAccountId"></param>
        /// <returns></returns>
        Task<IList<ExpenseModel>> GetAll(int virtualAccountId);
        /// <summary>
        /// Update Expense
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Update(ExpenseForm form);
        /// <summary>
        /// Delete Expense by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Delete(int id);
    }
}