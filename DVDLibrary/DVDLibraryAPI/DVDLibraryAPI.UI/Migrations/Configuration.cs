namespace DVDLibraryAPI.UI.Migrations
{
    using DVDLibraryAPI.UI.EFModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDLibraryAPI.UI.EFModels.DvdLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public static void DeleteAllFromDb()
        {
            var repo = new DvdRepositoryEntity();

            var dvds = repo.GetAll().ToList();

            // movie exists?
            foreach (var dvd in dvds)
            {
                int id = dvd.DvdId;
                repo.Delete(id);
            }

            Migrations.Configuration configuration = new Migrations.Configuration();
            DvdLibraryEntities entities = new DvdLibraryEntities();
            configuration.Seed(entities);
        }

        protected override void Seed(DVDLibraryAPI.UI.EFModels.DvdLibraryEntities context)
        {
            context.Ratings.AddOrUpdate(
                g => g.RatingName,
                new Rating { RatingName = "G" },
                new Rating { RatingName = "PG" },
                new Rating { RatingName = "PG-13" },
                new Rating { RatingName = "R" },
                new Rating { RatingName = "NC-17" }

             );

            context.SaveChanges();

            context.Dvds.AddOrUpdate(
                m => m.DvdId,
                new Dvd
                {
                    Title = "The Shawshank Redemption",
                    ReleaseYear = 1994,
                    Director = "Frank Darabont",
                    RatingId = context.Ratings.First(r => r.RatingName == "R").RatingId,
                    Notes = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."
                },

                new Dvd
                {
                    Title = "The Godfather",
                    ReleaseYear = 1972,
                    Director = "Francis Ford Coppola",
                    RatingId = context.Ratings.First(r => r.RatingName == "R").RatingId,
                    Notes = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
                },

                new Dvd
                {
                    Title = "The Godfather: Part II",
                    ReleaseYear = 1974,
                    Director = "Francis Ford Coppola",
                    RatingId = context.Ratings.First(r => r.RatingName == "R").RatingId,
                    Notes = "The early life and career of Vito Corleone in 1920s New York is portrayed while his son, Michael, expands and tightens his grip on the family crime syndicate."
                },

                new Dvd
                {
                    Title = "The Dark Knight",
                    ReleaseYear = 2008,
                    Director = "Christopher Nolan",
                    RatingId = context.Ratings.First(r => r.RatingName == "PG-13").RatingId,
                    Notes = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham, the Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice."
                },

                new Dvd
                {
                    Title = "12 Angry Men",
                    ReleaseYear = 1957,
                    Director = "Sidney Lumet",
                    RatingId = context.Ratings.First(r => r.RatingName == "PG").RatingId,
                    Notes = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence."
                },

                new Dvd
                {
                    Title = "Schindler's List",
                    ReleaseYear = 1993,
                    Director = "Steven Spielberg",
                    RatingId = context.Ratings.First(r => r.RatingName == "R").RatingId,
                    Notes = "In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazi Germans."
                },

                new Dvd
                {
                    Title = "Pulp Fiction",
                    ReleaseYear = 1994,
                    Director = "Quentin Tarantino",
                    RatingId = context.Ratings.First(r => r.RatingName == "R").RatingId,
                    Notes = "The lives of two mob hit men, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption."
                },

                new Dvd
                {
                    Title = "The Lord of the Rings: The Return of the King",
                    ReleaseYear = 2003,
                    Director = "Peter Jackson",
                    RatingId = context.Ratings.First(r => r.RatingName == "PG-13").RatingId,
                    Notes = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring."
                },

                new Dvd
                {
                    Title = "The Good, the Bad and the Ugly",
                    ReleaseYear = 1994,
                    Director = "Sergio Leone",
                    RatingId = context.Ratings.First(r => r.RatingName == "PG-13").RatingId,
                    Notes = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery."
                },

                new Dvd
                {
                    Title = "Fight Club",
                    ReleaseYear = 1999,
                    Director = "David Fincher",
                    RatingId = context.Ratings.First(r => r.RatingName == "R").RatingId,
                    Notes = "An insomniac office worker, looking for a way to change his life, crosses paths with a devil-may-care soap maker, forming an underground fight club that evolves into something much, much more."
                },

                new Dvd
                {
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    ReleaseYear = 2001,
                    Director = "Peter Jackson",
                    RatingId = context.Ratings.First(r => r.RatingName == "PG-13").RatingId,
                    Notes = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle Earth from the Dark Lord Sauron."
                },
                new Dvd
                {
                    Title = "Forrest Gump",
                    ReleaseYear = 1994,
                    Director = "Robert Zemeckis",
                    RatingId = context.Ratings.First(r => r.RatingName == "R").RatingId,
                    Notes = "JFK, LBJ, Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75."
                },

                new Dvd
                {
                    Title = "Star Wars: Episode V - The Empire Strikes Back",
                    ReleaseYear = 1980,
                    Director = "Irvin Kershner",
                    RatingId = context.Ratings.First(r => r.RatingName == "PG").RatingId,
                    Notes = "After the rebels are overpowered by the Empire on their newly established base, Luke Skywalker begins Jedi training with Master Yoda."
                },

                new Dvd
                {
                    Title = "Inception",
                    ReleaseYear = 2010,
                    Director = "Christopher Nolan",
                    RatingId = context.Ratings.First(r => r.RatingName == "PG-13").RatingId,

                    Notes = "A thief, who steals corporate secrets through use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO."
                }
            );
            context.SaveChanges();
        }
    }
}
