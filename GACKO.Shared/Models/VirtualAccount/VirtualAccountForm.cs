using GACKO.Shared.Models.BankAccount;

namespace GACKO.Shared.Models.VirtualAccount
{
    public class VirtualAccountForm
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public double NotificationBalance { get; set; }
        public int BankAccountId { get; set; }
    }
}
