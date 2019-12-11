using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    /// <summary>
    /// Subscription Table Data Access Object 
    /// </summary>
    [Table("Subscription")]
    public class DaoSubscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int FrequncyMonth { get; set; }
        public int VirtualAccountId { get; set; }

        [ForeignKey("VirtualAccountId")]
        public virtual DaoVirtualAccount VirtualAccount { get; set; }
    }
}
