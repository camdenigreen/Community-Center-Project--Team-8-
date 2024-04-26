CREATE OR ALTER PROCEDURE People.RetrieveAllMembers
@PhoneNumber NVARCHAR(14),
@LastName NVARCHAR(30)
AS
SELECT
    P.PersonID,
    P.FirstName,
    P.LastName,
    P.[Address],
    P.PhoneNumber,
    P.IsMember
FROM People.People AS P
WHERE (@LastName IS NOT NULL AND @LastName=P.LastName)
OR(@LastName IS NOT NULL AND P.LastName LIKE ('%' + @LastName +'%'))
OR(@PhoneNumber IS NOT NULL AND P.PhoneNumber= @PhoneNumber)
OR(@PhoneNumber IS NOT NULL AND P.PhoneNumber LIKE( '%' + @PhoneNumber + '%'))
OR (@PhoneNumber IS NULL AND @LastName IS NULL)
AND
    P.IsMember = 1;

GO
