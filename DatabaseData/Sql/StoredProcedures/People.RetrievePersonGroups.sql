CREATE OR ALTER PROCEDURE People.RetrievePersonGroups
    @PersonId INT
AS

SELECT
    G.GroupID,
    G.Name,
    G.Description
FROM People.Groups AS G
INNER JOIN People.PeopleGroups AS PG ON G.GroupID = PG.GroupID
WHERE @PersonID = PG.PersonID;

GO
