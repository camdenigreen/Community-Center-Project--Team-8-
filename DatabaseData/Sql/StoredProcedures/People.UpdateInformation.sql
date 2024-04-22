CREATE OR ALTER PROCEDURE People.UpdateInformation
    @PersonId INT,
    @Address NVARCHAR(100),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PhoneNumber NVARCHAR(20)
AS

UPDATE People.People
SET
    Address = @Address,
    FirstName = @FirstName,
    LastName = @LastName,
    PhoneNumber = @PhoneNumber

WHERE PersonID = @PersonId;

GO
