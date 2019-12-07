namespace GACKO.Shared.Models.BankAccount
{
    public class BankAccountForm
    {
        public int? Id { get; set; }
        public string Iban { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
