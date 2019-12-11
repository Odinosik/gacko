using System.Collections.Generic;

namespace GACKO.Shared.Models.Expense
{
    public class ExpenseListViewModel : GackoBaseViewModel
    {
        public int VirtualAccountId { get; set; }
        public virtual IEnumerable<ExpenseModel> Expenses { get; set; }
    }
}
