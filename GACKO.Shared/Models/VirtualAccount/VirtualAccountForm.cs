using GACKO.Shared.Models.BankAccount;

namespace GACKO.Shared.Models.VirtualAccount
{
    public class VirtualAccountForm
    {
        public string Name { get; set; }
        public float Balance { get; set; }
        public float Limit { get; set; }
        public float NotificationBalance { get; set; }
        public int BankAccountId { get; set; }
    }
}
