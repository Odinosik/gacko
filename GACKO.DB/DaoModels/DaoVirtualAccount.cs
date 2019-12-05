using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    [Table("VirtualAccount")]
    public class DaoVirtualAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public double Limit { get; set; }
        public double NotificationBalance { get; set; }
        public int BankAccountId { get; set; }
        [ForeignKey("BankAccountId")]
        public virtual DaoBankAccount BankAccount { get; set; }
    }
}
