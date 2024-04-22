CREATE OR ALTER PROCEDURE People.UpdateFirstName
    @PersonID INT,
    @FirstName NVARCHAR(30)
AS

UPDATE People.People
SET FirstName=@FirstName
WHERE PersonID=@PersonID
    
GO
