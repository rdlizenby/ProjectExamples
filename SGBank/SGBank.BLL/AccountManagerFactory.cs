using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;  // has a class in it that can read the App.config file
using SGBank.Data;

namespace SGBank.BLL
{
    public static class AccountManagerFactory  //Factory class - classes whose only purpose is to instantiate objects that require setup (like dependency injection)
    {
        public static AccountManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                case "BasicTest":
                    return new AccountManager(new BasicAccountTestRepository());
                case "PremiumTest":
                    return new AccountManager(new PremiumAccountTestRepository());
                case "FileAccount":
                    return new AccountManager(new FileAccountRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
