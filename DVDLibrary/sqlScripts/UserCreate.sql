USE master
GO
 
CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DVDLibrary
GO
 
CREATE USER DvdLibraryApp FOR LOGIN DVDLibraryApp
GO

GRANT EXECUTE ON DvdDelete TO DvdLibraryApp
GRANT EXECUTE ON DvdSearchResults TO DvdLibraryApp
GRANT EXECUTE ON DvdUpdate TO DvdLibraryApp
GRANT EXECUTE ON GetAll TO DvdLibraryApp
GRANT EXECUTE ON GetById TO DvdLibraryApp
GRANT EXECUTE ON InsertDvd TO DvdLibraryApp

GRANT SELECT ON Dvd TO DvdLibraryApp
GRANT INSERT ON Dvd TO DvdLibraryApp
GRANT UPDATE ON Dvd TO DvdLibraryApp
GRANT DELETE ON Dvd TO DvdLibraryApp
GO