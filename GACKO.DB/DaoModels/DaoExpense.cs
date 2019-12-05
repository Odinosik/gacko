﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    [Table("Expense")]
    public class DaoExpense
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public int VirtualAccountId { get; set; }
        [ForeignKey("VirtualAccountId")]
        public virtual DaoVirtualAccount VirtualAccount { get; set; }
        public int ExpenseCategoryId { get; set; }
        [ForeignKey("ExpenseCategoryId")]
        public virtual DaoExpenseCategory ExpenseCategory { get; set; }
    }
}
