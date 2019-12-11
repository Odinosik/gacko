using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    /// <summary>
    /// BankAccount Table Data Access Object 
    /// </summary>
    [Table("BankAccount")]
    public class DaoBankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iban { get; set; }
        public double Balance { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual DaoUser User { get; set; }
}
}