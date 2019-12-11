using System.Collections.Generic;

namespace GACKO.Shared.Models.BankAccount
{
    /// <summary>
    /// Bank Account View Model
    /// </summary>
    public class BankAccountListViewModel : GackoBaseViewModel
    {
        /// <summary>
        /// List of Bank Accounts
        /// </summary>
        public IList<BankAccountModel> BankAccounts { get; set; }
    }
}
