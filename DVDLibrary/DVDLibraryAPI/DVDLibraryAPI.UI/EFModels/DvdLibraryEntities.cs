using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVDLibraryAPI.UI.EFModels
{
    public class DvdLibraryEntities : DbContext
    {
        public DvdLibraryEntities()
            : base ("CodeFirst")
        {
        }
        public DbSet<Dvd> Dvds { get; set; }
        public DbSet<Rating> Ratings { get; set; }


    }
}