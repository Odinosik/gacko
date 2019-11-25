using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    [Table("SalesDocument")]
    public class DaoSalesDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        public virtual DaoExpense Expense { get; set; }
}
}
