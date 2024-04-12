CREATE OR ALTER PROCEDURE UpdateAddress
    @PersonID INT,
    @Address NVARCHAR(100)
    
AS 

UPDATE People.People
    SET [Address]=@Address
    WHERE PersonID=@PersonID
    
GO