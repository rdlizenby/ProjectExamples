using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.Tests
{
    [TestFixture]
    public class CsvImportExportTests
    {
        private const string _filePath = @"C:\Users\Rorie\Documents\bitbucket\rorie-lizenby-individual-work\SGBank\SGBank.Tests\bin\Debug\Accounts.txt";
        private const string _originalData = @"C:\Users\Rorie\Documents\bitbucket\rorie-lizenby-individual-work\SGBank\SGBank.Tests\bin\Debug\AccountsSeed.txt";

        [SetUp]
        public void Setup()
        {
            if(File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            File.Copy(_originalData, _filePath);
        }

        [Test]
        public void CanReadCvs()
        {
            FileAccountRepository repo = new FileAccountRepository();

            Account account = new Account();
            Dictionary<string, Account> accounts = new Dictionary<string, Account>();
            accounts = repo.ReadAccountCSV(_filePath);

            Account check = accounts["22222"];

            Assert.AreEqual("22222", check.AccountNumber);
            Assert.AreEqual("Basic Customer", check.Name);
            Assert.AreEqual(500, check.Balance);
            Assert.AreEqual(AccountType.Basic, check.Type);
        }

        [Test]
        public void CanCreateCvsForAccount()
        {
            FileAccountRepository repo = new FileAccountRepository();

            Account account = new Account();
            account.AccountNumber = "12345";
            account.Name = "Rorie Lizenby";
            account.Balance = 255;
            account.Type = AccountType.Premium;

            string result = repo.CreateCsvForAccount(account);

            Assert.AreEqual(result, "12345,Rorie Lizenby,255,P");
        }
    }
}
