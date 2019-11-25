﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GACKO.DB.DaoModels
{
    [Table("BankAccount")]
    public class DaoBankAccount
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public float Balance { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual DaoUser User { get; set; }
}
}