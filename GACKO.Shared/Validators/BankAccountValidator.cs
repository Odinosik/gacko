using FluentValidation;
using GACKO.Shared.Models.BankAccount;
using System;
using System.Collections.Generic;
using System.Text;

namespace GACKO.Shared.Validators
{
    public class BankAccountValidator : AbstractValidator<BankAccountForm>
    {
        public BankAccountValidator()
        {
            RuleFor(x => x.Iban).NotEmpty().Length(30);
        }
    }
}
