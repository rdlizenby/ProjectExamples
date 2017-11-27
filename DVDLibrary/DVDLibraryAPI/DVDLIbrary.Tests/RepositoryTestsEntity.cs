using DVDLibraryAPI.UI.EFModels;
using NUnit.Framework;
using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;



namespace DVDLIbrary.Tests
{
    [TestFixture]
    public class RepositoryTestsEntity
    {
        [SetUp]
        public void DeleteAllFromDb()
        {
            DVDLibraryAPI.UI.Migrations.CallDeleteAll.makeCall();
        }

       
        [Test]
        public void CanLoadDvds()
        {
            var repo = new DvdRepositoryEntity();

            var dvds = repo.GetAll().ToList();

            Assert.AreEqual(14, dvds.Count());

            Assert.AreEqual("12 Angry Men", dvds[4].Title);
            Assert.AreEqual(1957, dvds[4].ReleaseYear);
            Assert.AreEqual("Sidney Lumet", dvds[4].Director);
            Assert.AreEqual("PG", dvds[4].Rating);
            Assert.AreEqual("A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", dvds[4].Notes);
        }

        [Test]
        public void CanAddDvd()
        {
            DVDLibrary.Models.Dvd dvd = new DVDLibrary.Models.Dvd();
            var repo = new DvdRepositoryEntity();
            dvd.Title = "Frozen";
            dvd.ReleaseYear = 2008;
            dvd.Director = "Disney";
            dvd.Rating = "G";
            dvd.Notes = "Brr... So cold.";
            repo.Insert(dvd);

            var dvdx = repo.GetBySearch("title", "Frozen").First();

            Assert.AreEqual("Disney", dvdx.Director);
        }

        [Test]
        public void CanLoadDvdById()
        {
            var repo = new DvdRepositoryEntity();

            var dvds = repo.GetAll().ToList();

            int TestId = dvds[4].DvdId;

            var TestDvd = repo.GetById(TestId);

            Assert.AreEqual("12 Angry Men", TestDvd.Title);
            Assert.AreEqual(1957, TestDvd.ReleaseYear);
            Assert.AreEqual("Sidney Lumet", TestDvd.Director);
            Assert.AreEqual("PG", TestDvd.Rating);
            Assert.AreEqual("A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", TestDvd.Notes);
        }

        [Test]
        public void CanDelete()
        {
            var repo = new DvdRepositoryEntity();

            var dvds = repo.GetAll().ToList();

            int TestId = dvds[4].DvdId;

            repo.Delete(TestId);

            Assert.AreEqual(13, repo.GetAll().Count());
        }
    }
}
