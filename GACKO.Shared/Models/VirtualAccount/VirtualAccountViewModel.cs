using System.Collections.Generic;
using GACKO.Shared.Models.Expense;

namespace GACKO.Shared.Models.VirtualAccount
{
    public class VirtualAccountViewModel
    {
        public VirtualAccountModel SelectedVirtualAccount { get; set; }
        public IEnumerable<VirtualAccountModel> VirtualAccounts { get; set; }
        public double expSum { get; set; }
        public double subSum { get; set; }
    }
}
