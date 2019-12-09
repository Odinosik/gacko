using GACKO.Shared.Models.BankAccount;
using GACKO.Shared.Models.Expense;
using System.Collections.Generic;
using GACKO.Shared.Models.Subscription;

namespace GACKO.Shared.Models.VirtualAccount
{
    public class VirtualAccountViewModel
    {
        public VirtualAccountModel SelectedVirtualAccount { get; set; }
        public IEnumerable<VirtualAccountModel> VirtualAccounts { get; set; }
    }
}
