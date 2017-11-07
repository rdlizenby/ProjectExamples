using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data.InterfaceAndFactory
{
    public interface IDvdRepository
    {
        Dvd GetById(int dvdId);
        void Insert(Dvd dvd);
        void Update(Dvd dvd);
        void Delete(int dvd);
        IEnumerable<Dvd> GetAll();
        IEnumerable<Dvd> GetBySearch(string category, string searchTerm);
    }
}
