namespace GACKO.Shared.Models.BankAccount
{
    public class BankAccountForm
    {
        int? Id { get; set; }
        public string Iban { get; set; }
        public float Balance { get; set; }
        public int UserId { get; set; }
    }
}
