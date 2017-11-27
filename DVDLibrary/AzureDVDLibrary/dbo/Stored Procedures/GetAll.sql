
CREATE PROCEDURE GetAll AS
BEGIN
	SELECT DvDId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd 
		JOIN Rating on Dvd.RatingId = Rating.RatingId
END 
