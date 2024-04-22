CREATE OR ALTER PROCEDURE People.UpdateLastName
    @PersonID INT,
    @LastName LastName
AS 

UPDATE People.People
SET LastName=@LastName
WHERE PersonID=@PersonID
    
GO