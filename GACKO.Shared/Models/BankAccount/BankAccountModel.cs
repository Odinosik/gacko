using GACKO.Shared.Models.User;

namespace GACKO.Shared.Models.BankAccount
{
    /// <summary>
    /// Bank Account Model representing database entity DaoBankAccount
    /// </summary>
    public class BankAccountModel
    {
        /// <summary>
        /// Bank Account ID
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Bank Account Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// International Bank Account Number
        /// </summary>
        public string Iban { get; set; }
        /// <summary>
        /// Bank Account Balance
        /// </summary>
        public double Balance { get; set; }
        /// <summary>
        /// Flag indicating whether the Bank Account is active
        /// </summary>
        public bool IsActive { get; set; } = true;
        /// <summary>
        /// ID of an User of whom the Bank Account is
        /// </summary>
        public int UserId { get; set; }
        public UserProfile User { get; set; }
    }
}
