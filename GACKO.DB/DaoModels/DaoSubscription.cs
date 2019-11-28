using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    [Table("Subscription")]
    public class DaoSubscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime? Date { get; set; }
        public int VirtualAccountId { get; set; }
        [ForeignKey("VirtualAccountId")]
        public virtual DaoVirtualAccount VirtualAccount { get; set; }
    }
}
