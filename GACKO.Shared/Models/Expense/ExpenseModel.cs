using System;
using System.Collections.Generic;
using GACKO.Shared.Models.ExpenseCategory;
using GACKO.Shared.Models.SalesDocument;
using GACKO.Shared.Models.VirtualAccount;

namespace GACKO.Shared.Models.Expense
{
    /// <summary>
    /// Expense Model representing database entity
    /// </summary>
    public class ExpenseModel
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int VirtualAccountId { get; set; }
        public VirtualAccountModel VirtualAccount { get; set; }
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategoryModel ExpenseCategory { get; set; }
        public virtual IEnumerable<SalesDocumentModel> SalesDocuments { get; set; }
    }
}
