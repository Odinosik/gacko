using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    [Table("ExpenseCategory")]
    public class DaoExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
