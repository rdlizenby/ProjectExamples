
CREATE PROCEDURE InsertDvd (
	@DvdId varchar(50) output,
	@Title varchar(50),
	@ReleaseYear int,
	@Director varchar(30),
	@Rating varchar(5),
	@Notes varchar(500)
) AS
BEGIN
	INSERT INTO Dvd(ReleaseYear, Title, Director, RatingId, Notes)
	VALUES(@ReleaseYear, @Title, @Director, (SELECT TOP 1 RatingId FROM Rating WHERE @Rating = Rating), @Notes) 

	SET @DvdId = SCOPE_IDENTITY();
END 
