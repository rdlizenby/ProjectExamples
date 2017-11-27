
CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Dvd;
	DELETE FROM Rating;

	DBCC CHECKIDENT ('Dvd', RESEED, 1)
	DBCC CHECKIDENT ('Rating', RESEED, 1)

	SET IDENTITY_INSERT Rating ON;
		INSERT INTO Rating (RatingId, Rating)
		VALUES (1, 'G'),
		(2, 'PG'),
		(3, 'PG-13'),
		(4, 'R'),
		(5, 'NC-17')
	SET IDENTITY_INSERT Rating OFF;

	SET IDENTITY_INSERT Dvd ON;
		INSERT INTO Dvd (DvdId, Title, ReleaseYear, Director, RatingId, Notes)
		VALUES ( 1, 'The Shawshank Redemption', 1994, 'Frank Darabont', 4,  'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.'),
				( 2, 'The Godfather',  1972, 'Francis Ford Coppola',  4, 'The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.'),
				(3, 'The Godfather: Part II', 1974, 'Francis Ford Coppola', 4, 'The early life and career of Vito Corleone in 1920s New York is portrayed while his son, Michael, expands and tightens his grip on the family crime syndicate.'),
				(4, 'The Dark Knight', 2008, 'Christopher Nolan', 3,'When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham, the Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.' ),
				(5, '12 Angry Men', 1957, 'Sidney Lumet', 2, 'A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.' ),
				(6, 'Schindler''s List', 1993, 'Steven Spielberg', 4, 'In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazi Germans.'),
				(7, 'Pulp Fiction',  1994, 'Quentin Tarantino', 4, 'The lives of two mob hit men, a boxer, a gangster''s wife, and a pair of diner bandits intertwine in four tales of violence and redemption.'),
				(8, 'The Lord of the Rings: The Return of the King', 2003, 'Peter Jackson', 3, 'Gandalf and Aragorn lead the World of Men against Sauron''s army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.'),
				(9, 'The Good, the Bad and the Ugly', 1994, 'Sergio Leone', 3, 'A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.'),
				(10, 'Fight Club', 1999, 'David Fincher', 4, 'An insomniac office worker, looking for a way to change his life, crosses paths with a devil-may-care soap maker, forming an underground fight club that evolves into something much, much more.'),
				(11, 'The Lord of the Rings: The Fellowship of the Ring', 2001, 'Peter Jackson', 3, 'A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle Earth from the Dark Lord Sauron.'),
				(12, 'Forrest Gump', 1994, 'Robert Zemeckis', 3, 'JFK, LBJ, Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75.' ),
				(13, 'Star Wars: Episode V - The Empire Strikes Back', 1980, 'Irvin Kershner', 2, 'After the rebels are overpowered by the Empire on their newly established base, Luke Skywalker begins Jedi training with Master Yoda.'),
				(14, 'Inception', 2010, 'Christopher Nolan', 5, 'A thief, who steals corporate secrets through use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO.')
	SET IDENTITY_INSERT Dvd OFF;
END
