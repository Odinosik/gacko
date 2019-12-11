using GACKO.Shared.Models.Expense;

namespace GACKO.Shared.Models.SalesDocument
{
    /// <summary>
    /// Sales Document Model representing database entity DaoSalesDocument
    /// </summary>
    public class SalesDocumentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] FileRawData { get; set; }
        public int ExpenseId { get; set; }
        public ExpenseModel Expense { get; set; }
    }
}
