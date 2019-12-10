using System.Collections.Generic;

namespace GACKO.Shared.Models.BankAccount
{
    public class BankAccountListViewModel : GackoBaseViewModel
    {
        public IList<BankAccountModel> BankAccounts { get; set; }
    }
}
