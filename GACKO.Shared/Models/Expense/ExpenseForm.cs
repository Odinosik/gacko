using System;

namespace GACKO.Shared.Models.Expense
{
    /// <summary>
    /// Create and Update Expense Form
    /// </summary>
    public class ExpenseForm
    {
        public double Amount { get; set; }
        public string Name { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int VirtualAccountId { get; set; }
        public int ExpenseCategoryId { get; set; }
    }
}
