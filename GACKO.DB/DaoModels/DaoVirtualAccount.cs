using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    [Table("VirtualAccount")]
    public class DaoVirtualAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
        public float Limit { get; set; }
        public float NotificationBalance { get; set; }
        public int BankAccountId { get; set; }
        [ForeignKey("BankAccountId")]
        public virtual DaoBankAccount BankAccount { get; set; }
    }
}
