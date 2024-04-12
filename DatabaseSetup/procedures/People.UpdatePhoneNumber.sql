CREATE OR ALTER PROCEDURE UpdateAddress
    @PersonID INT,
    @PhoneNumber NVARCHAR(20)
    
AS 

UPDATE People.People
    SET PhoneNumber=@PhoneNumber
    WHERE PersonID=@PersonID
    
GO