﻿using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.DepositRules
{
    public class NoLimitDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            if (account.Type != AccountType.Basic && account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Only basic and premium accounts can deposit with no limit. Contact IT";
                return response;
            }

            if (amount <= 0)
            {
                response.Success = false;
                response.Message="Deposit amounts much be positive!";
                return response;
            }

            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = response.Account.Balance;
            response.Account.Balance = response.Account.Balance + amount;
            return response;
        }
    }
}
