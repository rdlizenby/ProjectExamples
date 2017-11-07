using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Configuration;
using DVDLibrary.Data;
using DVDLibrary.Models;
using DVDLibrary.Data.InterfaceAndFactory;

namespace DVDLIbrary.Tests
{
    [TestFixture]
    public class RepositoryTestsADO
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestingConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadDvds()
        {
            var repo = new DvdRepositoryADO();

            var dvds = repo.GetAll().ToList();

            Assert.AreEqual(14, dvds.Count());
        
            Assert.AreEqual("12 Angry Men", dvds[4].Title);
            Assert.AreEqual(1957, dvds[4].ReleaseYear);
            Assert.AreEqual("Sidney Lumet", dvds[4].Director);
            Assert.AreEqual("PG", dvds[4].Rating);
            Assert.AreEqual("A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", dvds[4].Notes);
        }

        [Test]
        public void CanLoadDvdById()
        {
            var repo = new DvdRepositoryADO();
            Dvd dvd = repo.GetById(5);

            Assert.AreEqual("12 Angry Men", dvd.Title);
            Assert.AreEqual(1957, dvd.ReleaseYear);
            Assert.AreEqual("Sidney Lumet", dvd.Director);
            Assert.AreEqual("PG", dvd.Rating);
            Assert.AreEqual("A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", dvd.Notes);
        }

        [Test]
        public void CanSearchByTitle()
        {
            var repo = new DvdRepositoryADO();
            var dvds = repo.GetBySearch("title", "Fight Club");

            Assert.AreEqual(1, dvds.Count());
        }

        [Test]
        public void CanSearchByRating()
        {
            var repo = new DvdRepositoryADO();
            var dvds = repo.GetBySearch("rating", "R");

            Assert.AreEqual(6, dvds.Count());
        }

        [Test]
        public void CanSearchByDirector()
        {
            var repo = new DvdRepositoryADO();
            var dvds = repo.GetBySearch("director", "Peter Jackson");

            Assert.AreEqual(2, dvds.Count());
        }

        [Test]
        public void CanAddDvd()
        {
            Dvd dvd = new Dvd();
            var repo = new DvdRepositoryADO();
            dvd.Title = "The Lord of the Rings: The Two Towers";
            dvd.ReleaseYear = 2002;
            dvd.Director = "Peter Jackson";
            dvd.Rating = "PG-13";
            dvd.Notes = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.";

            repo.Insert(dvd);

            Assert.AreEqual(15, dvd.DvdId);
            Assert.AreEqual("The Lord of the Rings: The Two Towers", dvd.Title);
        }

        [Test]
        public void CanUpdateDvd()
        {
            Dvd dvd = new Dvd();
            var repo = new DvdRepositoryADO();

            dvd.Title = "The Lord of the Rings: The Two Towers";
            dvd.ReleaseYear = 2002;
            dvd.Director = "Peter Jackson";
            dvd.Rating = "PG-13";
            dvd.Notes = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.";

            repo.Insert(dvd);
            dvd = repo.GetById(15);

            dvd.Title = "Goodfellas";
            dvd.ReleaseYear = 1990;
            dvd.Director = "Martin Scorsese";
            dvd.Rating = "R";
            dvd.Notes = "The story of Henry Hill and his life through the teen years into the years of mafia, covering his relationship with his wife Karen Hill and his Mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.";

            repo.Update(dvd);

            Dvd updatedDvd = repo.GetById(15);
            Assert.AreEqual("Goodfellas", updatedDvd.Title);
            Assert.AreEqual(1990, updatedDvd.ReleaseYear);
            Assert.AreEqual("Martin Scorsese", updatedDvd.Director);
            Assert.AreEqual("R", updatedDvd.Rating);
            Assert.AreEqual("The story of Henry Hill and his life through the teen years into the years of mafia, covering his relationship with his wife Karen Hill and his Mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.", updatedDvd.Notes);
        }

        [Test]
        public void CanDeleteDvd()
        {
            Dvd dvd = new Dvd();
            var repo = new DvdRepositoryADO();

            repo.Delete(4);

            var dvds = repo.GetAll();

            Assert.AreEqual(13, dvds.Count());
            Assert.AreEqual(null, repo.GetById(4));
        }
    }
}
