USE DVDLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAll')
		DROP PROCEDURE GetAll
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InsertDvd')
		DROP PROCEDURE InsertDvd
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetById')
		DROP PROCEDURE GetById
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdUpdate')
		DROP PROCEDURE DvdUpdate
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdDelete')
		DROP PROCEDURE DvdDelete
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdSearchResults')
		DROP PROCEDURE DvdSearchResults
GO

CREATE PROCEDURE GetAll AS
BEGIN
	SELECT DvDId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd 
		JOIN Rating on Dvd.RatingId = Rating.RatingId
END 
GO

CREATE PROCEDURE GetById (
	@DvdId int
) AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd 
		JOIN Rating on Dvd.RatingId = Rating.RatingId
	WHERE @DvdId = DvdId;
END
GO

CREATE PROCEDURE DvdDelete (
	@DvdId int
)AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Dvd WHERE DvdId = @DvdId

	COMMIT TRANSACTION
END
GO

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
GO

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
GO

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
GO				 