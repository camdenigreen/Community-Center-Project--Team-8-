CREATE PROCEDURE People.RetrieveGroupsByPersonID
    @PersonID INT
AS

SELECT
    G.Name,
    G.Description
FROM People.Groups AS G
INNER JOIN People.PeopleGroups AS PG ON G.GroupID = PG.GroupID
AND  PG.PersonID = @PersonID

GO
