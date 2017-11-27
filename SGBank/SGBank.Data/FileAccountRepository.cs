using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private const string FilePath = @"C:.\Accounts.txt";
        Dictionary<string, Account> accounts = new Dictionary<string ,Account>();

        public Dictionary<string, Account> ReadAccountCSV(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine();  //get past the header?
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Account account = new Account();

                    string[] columns = line.Split(',');

                    account.AccountNumber = columns[0];
                    account.Name = columns[1];
                    account.Balance = Decimal.Parse(columns[2]);

                    if (columns[3] == "F")
                        account.Type = AccountType.Free;
                    if (columns[3] == "B")
                            account.Type = AccountType.Basic;
                    if (columns[3] == "P")
                        account.Type = AccountType.Premium;

                    accounts.Add(account.AccountNumber, account);
                }
            }
            return accounts;
        }

        public Account LoadAccount(string AccountNumber)
        {
            ReadAccountCSV(FilePath);
            if (accounts.Keys.Contains(AccountNumber))
                {
                return accounts[AccountNumber];
                }
            else
            {
                return null;
            }
        }

        public void SaveAccount(Account accout)
        {
            accounts[accout.AccountNumber] = accout;

            if (File.Exists(FilePath))
                File.Delete(FilePath);

            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                sw.WriteLine("AccountNumber,Name,Balance,Type"); //header
                foreach(var account in accounts)
                {
                    sw.WriteLine(CreateCsvForAccount(account.Value));
                }
            }
        }

        public string CreateCsvForAccount(Account account)
        {
            string type;
            if (account.Type == AccountType.Free)
                type = "F";
            else if (account.Type == AccountType.Basic)
                type = "B";
            else
                type = "P";

            return string.Format("{0},{1},{2},{3}", account.AccountNumber, account.Name, account.Balance, type);
        }
    }
}
