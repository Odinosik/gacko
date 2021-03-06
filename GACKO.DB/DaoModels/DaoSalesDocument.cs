﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    /// <summary>
    /// SalesDocument Table Data Access Object 
    /// </summary>
    [Table("SalesDocument")]
    public class DaoSalesDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] FileRawData { get; set; }
        public int ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        public virtual DaoExpense Expense { get; set; }
}
}
