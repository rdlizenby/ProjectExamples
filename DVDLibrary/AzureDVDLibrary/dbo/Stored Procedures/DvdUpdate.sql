
CREATE PROCEDURE DvdUpdate (
	@DvdId int,
	@Title varchar(50),
	@ReleaseYear int,
	@Director varchar(30),
	@Rating varchar(5),
	@Notes varchar(500)
)AS
BEGIN
	UPDATE Dvd SET
	Title = @Title, 
	ReleaseYear = @ReleaseYear, 
	Director = @Director, 
	RatingId = (SELECT TOP 1 RatingId FROM Rating WHERE @Rating = Rating), 
	Notes = @Notes 
	WHERE DvdId = @DvdId
END
