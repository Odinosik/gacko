using System.Collections.Generic;

namespace GACKO.Shared.Models.VirtualAccount
{
    public class VirtualAccountViewModel : GackoBaseViewModel
    {
        public VirtualAccountModel SelectedVirtualAccount { get; set; }
        public IEnumerable<VirtualAccountModel> VirtualAccounts { get; set; }
        public double expSum { get; set; }
        public double subSum { get; set; }
    }
}
