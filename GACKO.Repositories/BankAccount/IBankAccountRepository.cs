﻿using GACKO.Shared.Models.BankAccount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GACKO.Repositories.BankAccount
{
    public interface IBankAccountRepository
    {
        Task<int> Create(BankAccountForm form);
        Task<BankAccountModel> Get(int id);
        Task<int> Update(BankAccountForm form);
        Task<int> Delete(int id);
    }
}
