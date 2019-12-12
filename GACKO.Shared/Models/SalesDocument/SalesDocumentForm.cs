using GACKO.Shared.Models.Expense;

namespace GACKO.Shared.Models.SalesDocument
{
    /// <summary>
    /// Upload Sales Document  Form
    /// </summary>
    public class SalesDocumentForm
    {
        public string Name { get; set; }
        public byte[] FileRawData { get; set; }
        public int ExpenseId { get; set; }
    }
}
