using GACKO.Shared.Models.ExpenseCategory;
using GACKO.Shared.Models.VirtualAccount;

namespace GACKO.Shared.Models.Expense
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string Name { get; set; }
        public int VirtualAccountId { get; set; }
        public VirtualAccountModel VirtualAccount { get; set; }
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategoryModel ExpenseCategory { get; set; }
    }
}
