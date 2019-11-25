using GACKO.Shared.Models.BankAccount;

namespace GACKO.Shared.Models.VirtualAccount
{
    public class VirtualAccountModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
        public float Limit { get; set; }
        public float NotificationBalance { get; set; }
        public int BankAccountId { get; set; }
        public BankAccountModel BankAccount { get; set; }
    }
}
