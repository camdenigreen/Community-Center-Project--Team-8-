CREATE OR ALTER PROCEDURE People.RetrieveOtherGroups
    @PersonId INT

AS
SELECT
    G.GroupID,
    G.Name,
    G.Description

FROM People.Groups AS G
LEFT JOIN People.PeopleGroups  PG ON G.GroupID = PG.GroupID AND PG.PersonID= @PersonId
WHERE PG.PersonID IS NULL 
GO
