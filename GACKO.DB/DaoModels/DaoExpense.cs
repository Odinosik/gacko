using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    /// <summary>
    /// Expense Table Data Access Object 
    /// </summary>
    [Table("Expense")]
    public class DaoExpense
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int VirtualAccountId { get; set; }
        [ForeignKey("VirtualAccountId")]
        public virtual DaoVirtualAccount VirtualAccount { get; set; }
        public int ExpenseCategoryId { get; set; }
        [ForeignKey("ExpenseCategoryId")]
        public virtual DaoExpenseCategory ExpenseCategory { get; set; }
        public virtual IEnumerable<DaoSalesDocument> SalesDocuments { get; set; }
    }
}
