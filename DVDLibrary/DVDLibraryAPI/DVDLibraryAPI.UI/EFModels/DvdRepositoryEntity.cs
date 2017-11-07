using DVDLibrary.Data.InterfaceAndFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Models;
using System.Collections;
using System.Data.Entity;

namespace DVDLibraryAPI.UI.EFModels
{
    public class DvdRepositoryEntity : IDvdRepository
    {
        public object Dvds { get; internal set; }

        public void Delete(int dvd)
        {
            var repository = new DvdLibraryEntities();

            var dvdx = repository.Dvds.FirstOrDefault(m => m.DvdId == dvd);

            // movie exists?
            if (dvdx != null)
            {
                repository.Dvds.Remove(dvdx);
                repository.SaveChanges();
            }
        }

        public IEnumerable<DVDLibrary.Models.Dvd> GetAll()
        {
            var repository = new DvdLibraryEntities();

            var model = (from dvd in repository.Dvds
                         select new DVDLibrary.Models.Dvd
                         {
                             DvdId = dvd.DvdId,
                             Title = dvd.Title,
                             ReleaseYear = dvd.ReleaseYear,
                             Director = dvd.Director,
                             Rating = dvd.Rating.RatingName,        //fix this
                            Notes = dvd.Notes                           
                         });

            return model;
        }
        
        public DVDLibrary.Models.Dvd GetById(int dvdId)
        {
            var repository = new DvdLibraryEntities();
            var dvd = repository.Dvds.FirstOrDefault(m => m.DvdId == dvdId);
            DVDLibrary.Models.Dvd dvdx = new DVDLibrary.Models.Dvd();
            dvdx.DvdId = dvd.DvdId;
            dvdx.Title = dvd.Title;
            dvdx.ReleaseYear = dvd.ReleaseYear;
            dvdx.Director = dvd.Director;
            dvdx.Rating = dvd.Rating.RatingName;                    //fix this
            dvdx.Notes = dvd.Notes;
            return dvdx;
        }

        public IEnumerable<DVDLibrary.Models.Dvd> GetBySearch(string category, string searchTerm)
        {
            var repository = new DvdLibraryEntities();

            if (category == "title")
            {
                var dvdx = (from dvd in repository.Dvds
                           where dvd.Title.Contains(searchTerm)
                           select new DVDLibrary.Models.Dvd
                           {
                               DvdId = dvd.DvdId,
                               Title = dvd.Title,
                               ReleaseYear = dvd.ReleaseYear,
                               Director = dvd.Director,
                               Rating = dvd.Rating.RatingName,          //fix this
                               Notes = dvd.Notes
                           });
                return dvdx;
            }
             else  if (category == "rating")
                       {
                           var dvdx = (from dvd in repository.Dvds
                                       where (dvd.Rating.RatingName == searchTerm)          //fix this
                                       select new DVDLibrary.Models.Dvd
                                       {
                                           DvdId = dvd.DvdId,
                                           Title = dvd.Title,
                                           ReleaseYear = dvd.ReleaseYear,
                                           Director = dvd.Director,
                                           Rating =  dvd.Rating.RatingName,          //fix this
                                           Notes = dvd.Notes
                                       });
                return dvdx;
            }

            else
            {
                var dvdx = (from dvd in repository.Dvds
                            where dvd.ReleaseYear.Equals(searchTerm)
                            select new DVDLibrary.Models.Dvd
                            {
                                DvdId = dvd.DvdId,
                                Title = dvd.Title,
                                ReleaseYear = dvd.ReleaseYear,
                                Director = dvd.Director,
                                Rating = dvd.Rating.RatingName,          //fix this
                                Notes = dvd.Notes
                            });
                return (dvdx);
            }
        }

        public void Insert(DVDLibrary.Models.Dvd dvd)
        {
            var repository = new DvdLibraryEntities();

            Dvd dvdx = new Dvd();
            dvdx.Title = dvd.Title;
            dvdx.RatingId = (from r in repository.Ratings where r.RatingName == dvd.Rating select r.RatingId).FirstOrDefault() ;                      //fix this
            dvdx.ReleaseYear = dvd.ReleaseYear;
            dvdx.Director = dvd.Director;
            dvdx.Notes = dvd.Notes;

            repository.Dvds.Add(dvdx);
            repository.SaveChanges();
            dvdx.RatingId = dvd.DvdId;
        }

        

        public void Update(DVDLibrary.Models.Dvd dvd)
        {
            var repository = new DvdLibraryEntities();

            Dvd model = new Dvd();
            model.DvdId = dvd.DvdId;
            model.Title = dvd.Title;
            model.ReleaseYear = dvd.ReleaseYear;
            model.Director = dvd.Director;
            model.RatingId = (from r in repository.Ratings where r.RatingName == dvd.Rating select r.RatingId).FirstOrDefault();                       //fix this
            model.Notes = dvd.Notes;

            repository.Entry(model).State = EntityState.Modified;
            repository.SaveChanges();
        }
    }
}