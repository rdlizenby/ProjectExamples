using Ninject;
using SGBank.Data;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class DIContainer
    {
        public static IKernel Kernel = new StandardKernel();

        static DIContainer()
        {
            string modeType = ConfigurationManager.AppSettings["Mode"].ToString();

            if (modeType == "FreeAccount")
                Kernel.Bind<IAccountRepository>().To<FreeAccountTestRepository>();
            else if (modeType == "BasicAccount")
                Kernel.Bind<IAccountRepository>().To<BasicAccountTestRepository>();
            else if (modeType == "PremiumAccount")
                Kernel.Bind<IAccountRepository>().To<PremiumAccountTestRepository>();
            else if (modeType == "FileAccount")
                Kernel.Bind<IAccountRepository>().To<FileAccountRepository>();
            else
                throw new Exception("Chooser key in app.config not set properly!");
        }
    }


}
