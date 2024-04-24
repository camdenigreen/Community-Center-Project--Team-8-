CREATE OR ALTER PROCEDURE People.RetrieveAllMembers

AS

SELECT
    P.PersonID,
    P.FirstName,
    P.LastName,
    P.Address,
    P.PhoneNumber,
    P.IsMember
FROM People.People AS P
WHERE
    P.IsMember = 1;

GO
