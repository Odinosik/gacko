﻿using GACKO.Shared.Models.User;

namespace GACKO.Shared.Models.BankAccount
{
    public class BankAccountModel
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public float Balance { get; set; }
        public int UserId { get; set; }
        public UserProfile User { get; set; }
    }
}
