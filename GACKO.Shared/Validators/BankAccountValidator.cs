using FluentValidation;
using GACKO.Shared.Models.BankAccount;
using System;
using System.Collections.Generic;
using System.Text;

namespace GACKO.Shared.Validators
{
    /// <summary>
    /// Bank Account Form validator
    /// </summary>
    public class BankAccountFormValidator : AbstractValidator<BankAccountForm>
    {
        public BankAccountFormValidator()
        {
            RuleFor(x => x.Iban).NotEmpty().Length(30);
        }
    }
}
