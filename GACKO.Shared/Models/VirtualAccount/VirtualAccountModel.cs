using GACKO.Shared.Models.BankAccount;
using GACKO.Shared.Models.Expense;
using System.Collections.Generic;

namespace GACKO.Shared.Models.VirtualAccount
{
    public class VirtualAccountModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public double NotificationBalance { get; set; }
        public int BankAccountId { get; set; }
        public BankAccountModel BankAccount { get; set; }
        public IEnumerable<ExpenseModel> Expenses { get; set; }
    }
}
