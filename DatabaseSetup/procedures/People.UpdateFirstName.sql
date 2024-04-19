CREATE OR ALTER PROCEDURE UpdateFirstName
    @PersonID INT,
    @FirstName NVARCHAR(30)
    
AS 

UPDATE People.People
    SET FirstName=@FirstName
    WHERE PersonID=@PersonID
    
GO