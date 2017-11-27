using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.BLL.DepositRules;
using SGBank.Models.Responses;
using SGBank.BLL.WithdrawRules;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("55555", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, 250, true)]

        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit depositRule = new NoLimitDepositRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            AccountDepositResponse response = depositRule.Deposit(account, amount);

            Assert.AreEqual(response.Success, expectedResult);
        }

        [TestCase("55555", "Premium Account", 100, AccountType.Free, -100, 100, false)] //wrong account type
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, 100, 100, false)] //attempt to withdraw a positive number
        [TestCase("55555", "Premium Account", 150, AccountType.Premium, -50, 100, true)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -150, -50, true)]  //no overdraft fee
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdrawRule = new PremiumAccountWithdrawRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            AccountWithdrawResponse response = withdrawRule.Withdraw(account, amount);

            Assert.AreEqual(response.Success, expectedResult);
        }
    }
}
