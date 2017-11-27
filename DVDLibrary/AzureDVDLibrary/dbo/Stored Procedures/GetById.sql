
CREATE PROCEDURE GetById (
	@DvdId int
) AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd 
		JOIN Rating on Dvd.RatingId = Rating.RatingId
	WHERE @DvdId = DvdId;
END
