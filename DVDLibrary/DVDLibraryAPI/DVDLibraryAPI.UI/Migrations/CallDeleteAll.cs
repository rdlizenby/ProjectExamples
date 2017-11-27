using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibraryAPI.UI.Migrations
{
    public static class CallDeleteAll
    {
        public static void makeCall()
        {
            Migrations.Configuration.DeleteAllFromDb();
        }
    }
}