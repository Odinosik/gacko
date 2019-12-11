using GACKO.Shared.Models.BankAccount;
using GACKO.Shared.Models.Expense;
using System.Collections.Generic;
using GACKO.Shared.Models.Subscription;

namespace GACKO.Shared.Models.VirtualAccount
{
    /// <summary>
    /// Virtual Account Model representing database entity DaoVirtualAccount
    /// </summary>
    public class VirtualAccountModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public double NotificationBalance { get; set; }
        public int BankAccountId { get; set; }
        public BankAccountModel BankAccountView { get; set; }
        public IEnumerable<ExpenseModel> Expenses { get; set; }
        public IEnumerable<SubscriptionModel> Subscriptions { get; set; }
    }
}
