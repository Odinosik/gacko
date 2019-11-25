namespace GACKO.Shared.Models.Expense
{
    public class ExpenseForm
    {
        public float Amount { get; set; }
        public string Name { get; set; }
        public int VirtualAccountId { get; set; }
        public int ExpenseCategoryId { get; set; }
    }
}
