CREATE OR ALTER PROCEDURE UpdateAddress
    @PersonID INT,
    @LastName LastName
    
AS 

UPDATE People.People
    SET LastName=@LastName
    WHERE PersonID=@PersonID
    
GO