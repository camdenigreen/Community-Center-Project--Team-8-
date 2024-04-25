CREATE OR ALTER PROCEDURE People.RetrievePeopleByGroupID
    @GroupID INT
AS

SELECT
    P.PersonID,
    P.FirstName,
    P.LastName,
    P.PhoneNumber,
    P.[Address]
FROM People.People P
    INNER JOIN People.PeopleGroups PG ON PG.PersonID = P.PersonID
WHERE P.IsMember = 1 AND
    PG.GroupID = @GroupID

GO
