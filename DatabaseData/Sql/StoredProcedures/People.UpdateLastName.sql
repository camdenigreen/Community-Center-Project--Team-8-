CREATE OR ALTER PROCEDURE People.UpdateLastName
    @PersonID INT,
    @LastName NVARCHAR(5)
AS 

UPDATE People.People
SET LastName=@LastName
WHERE PersonID=@PersonID
    
GO