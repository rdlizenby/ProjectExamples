
CREATE PROCEDURE DvdSearchResults (
	@category varchar(15),
	@searchTerm nvarchar(30)
)AS
BEGIN
	IF @category = 'title'
		SELECT DvDId, Title, ReleaseYear, Director, Rating, Notes
		FROM Dvd 
			JOIN Rating on Dvd.RatingId = Rating.RatingId
		WHERE Title = @searchTerm
	ELSE IF @category = 'director'
		SELECT DvDId, Title, ReleaseYear, Director, Rating, Notes
		FROM Dvd 
			JOIN Rating on Dvd.RatingId = Rating.RatingId
		WHERE Director = @searchTerm	
	ELSE 
		SELECT DvDId, Title, ReleaseYear, Director, Rating, Notes
		FROM Dvd 
			JOIN Rating on Dvd.RatingId = Rating.RatingId
		WHERE Rating = @searchTerm
END
