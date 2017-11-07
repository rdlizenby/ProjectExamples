USE DVDLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvd')
	DROP TABLE Dvd
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Rating')
	DROP TABLE Rating
GO

CREATE TABLE Rating (
	RatingId int identity(1,1) not null primary key,
	Rating varchar(5) not null
)

CREATE TABLE Dvd (
	DvdId int identity(1,1) not null primary key,
	Title varchar(50) not null,
	ReleaseYear int not null,
	Director varchar(30) not null,
	RatingId int not null foreign key references Rating(RatingId),
	Notes varchar(500)
)