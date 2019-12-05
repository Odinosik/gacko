using GACKO.Shared.Models.Expense;
using System.Threading.Tasks;

namespace GACKO.Services.Expense
{
    public interface IExpenseService
    {
        Task<int> Create(ExpenseForm form);
        Task<ExpenseModel> Get(int id);
        Task<int> Update(ExpenseForm form);
        Task<int> Delete(int id);
    }
}