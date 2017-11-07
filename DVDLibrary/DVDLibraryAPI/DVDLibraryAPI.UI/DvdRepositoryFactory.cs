using DVDLibrary.Data;
using DVDLibrary.Data.InterfaceAndFactory;
using DVDLibraryAPI.UI.EFModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DVDLibraryAPI.UI
{
    public class DvdRepositoryFactory
    {
        static IDvdRepository _mock = new DvdRepositoryMock();
        public static IDvdRepository GetRepository()
        {
            string repositoryType = ConfigurationManager.AppSettings["RepositoryType"].ToString();
            switch (repositoryType)
            {
                case "SampleData":
                    return _mock;
                case "ADO":
                    return new DvdRepositoryADO();
                case "EntityFrameWork":
                    return new DvdRepositoryEntity();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
