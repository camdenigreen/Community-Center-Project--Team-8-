CREATE OR ALTER PROCEDURE People.RetrieveAllMembers
    @PersonID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PhoneNumber NVARCHAR(20)
AS

SELECT
    P.PersonId,
    P.FirstName,
    P.LastName,
    P.Address
FROM People.People AS P
WHERE
    P.IsMember = 1
    OR (@PersonID IS NOT NULL AND @PersonID = P.PersonID)
    OR (@FirstName IS NOT NULL AND @FirstName = P.FirstName)
    OR (@LastName IS NOT NULL AND @LastName = P.LastName)
    OR (@PhoneNumber IS NOT NULL AND @PhoneNumber = P.PhoneNumber)
    OR (@PersonID IS NULL AND @FirstName IS NULL AND @LastName IS NULL AND @PhoneNumber IS NULL)

GO
