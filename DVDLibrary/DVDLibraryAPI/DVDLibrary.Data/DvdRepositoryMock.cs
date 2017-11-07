using DVDLibrary.Data.InterfaceAndFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;

namespace DVDLibrary.Data
{
    public class DvdRepositoryMock : IDvdRepository
    {
        static IEnumerable<Dvd> _dvds;
        int idCount = 15;

        public DvdRepositoryMock()
        {
            _dvds = new List<Dvd>()
            {
            new Dvd { DvdId = 1, Title = "The Shawshank Redemption", ReleaseYear = 1994, Director= "Frank Darabont", Rating="R", Notes= "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency." },
            new Dvd { DvdId = 2, Title = "The Godfather", ReleaseYear = 1972, Director = "Francis Ford Coppola", Rating = "R", Notes = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
            new Dvd { DvdId = 3, Title = "The Godfather: Part II", ReleaseYear = 1974, Director = "Francis Ford Coppola", Rating = "R", Notes = "The early life and career of Vito Corleone in 1920s New York is portrayed while his son, Michael, expands and tightens his grip on the family crime syndicate." },
            new Dvd { DvdId = 4, Title = "The Dark Knight", ReleaseYear = 2008, Director = "Christopher Nolan", Rating = "PG-13", Notes = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham, the Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice." },
            new Dvd { DvdId = 5, Title = "12 Angry Men", ReleaseYear = 1957, Director = "Sidney Lumet", Rating = "PG", Notes = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence." },
            new Dvd { DvdId = 6, Title = "Schindler's List", ReleaseYear = 1993, Director = "Steven Spielberg", Rating = "R", Notes = "In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazi Germans." },
            new Dvd { DvdId = 7, Title = "Pulp Fiction", ReleaseYear = 1994, Director = "Quentin Tarantino", Rating = "R", Notes = "The lives of two mob hit men, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption." },
            new Dvd { DvdId = 8, Title = "The Lord of the Rings: The Return of the King", ReleaseYear = 2003, Director = "Peter Jackson", Rating = "PG-13", Notes = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring." },
            new Dvd { DvdId = 9, Title = "The Good, the Bad and the Ugly", ReleaseYear = 1994, Director = "Sergio Leone", Rating = "PG-13", Notes = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery." },
            new Dvd { DvdId = 10, Title = "Fight Club", ReleaseYear = 1999, Director = "David Fincher", Rating = "R", Notes = "An insomniac office worker, looking for a way to change his life, crosses paths with a devil-may-care soap maker, forming an underground fight club that evolves into something much, much more." },
            new Dvd { DvdId = 11, Title = "The Lord of the Rings: The Fellowship of the Ring", ReleaseYear = 2001, Director = "Peter Jackson", Rating = "PG-13", Notes = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle Earth from the Dark Lord Sauron." },
            new Dvd { DvdId = 12, Title = "Forrest Gump", ReleaseYear = 1994, Director = "Robert Zemeckis", Rating = "PG-13", Notes = "JFK, LBJ, Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75." },
            new Dvd { DvdId = 13, Title = "Star Wars: Episode V - The Empire Strikes Back", ReleaseYear = 1980, Director = "Irvin Kershner", Rating = "PG", Notes = "After the rebels are overpowered by the Empire on their newly established base, Luke Skywalker begins Jedi training with Master Yoda." },
            new Dvd { DvdId = 14, Title = "Inception", ReleaseYear = 2010, Director = "Christopher Nolan", Rating = "PG-13", Notes = "A thief, who steals corporate secrets through use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO." }
            };
        }
        public void Delete(int dvd)
        {
            _dvds = _dvds.Where(i => i.DvdId != dvd).ToList();           
        }

        public IEnumerable<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd GetById(int DvdId)
        {
            return _dvds.Where(i => i.DvdId == DvdId).FirstOrDefault();
        }

        public IEnumerable<Dvd> GetBySearch(string category, string searchTerm)
        {
            if (category == "title")
                return _dvds.Where(i => i.Title == searchTerm).ToList();
            if (category == "rating")
                return  _dvds.Where(i => i.Rating == searchTerm).ToList();
            else
                return  _dvds.Where(i => i.Director == searchTerm).ToList();
        }

        public void Insert(Dvd dvd)
        {
            dvd.DvdId = idCount;
            idCount++;
            List<Dvd> list = _dvds.ToList();
            list.Add(dvd);
            _dvds = list;
        }

        public void Update(Dvd dvd)
        {
            _dvds = _dvds.Where(i => i.DvdId != dvd.DvdId).ToList();
            List<Dvd> list = _dvds.ToList();
            list.Add(dvd);
            _dvds = list;
        }
    }
}
