using GACKO.Shared.Models.Expense;

namespace GACKO.Shared.Models.SalesDocument
{
    public class SalesDocumentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] FilePath { get; set; }
        public int ExpenseId { get; set; }
        public ExpenseModel Expense { get; set; }
    }
}
