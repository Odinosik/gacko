using System.Collections.Generic;

namespace GACKO.Shared.Models.VirtualAccount
{
    public class VirtualAccountViewViewModel : GackoBaseViewModel
    {
        public VirtualAccountModel SelectedVirtualAccount { get; set; }
        public IEnumerable<VirtualAccountModel> VirtualAccounts { get; set; }
    }
}
