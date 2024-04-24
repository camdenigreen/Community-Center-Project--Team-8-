CREATE OR ALTER PROCEDURE People.RetrieveOtherGroups
    @PersonId INT

AS
SELECT
    G.GroupID,
    G.Name,
    G.Description
FROM People.Groups AS G
--INNER JOIN People.PeopleGroups  PG ON G.GroupID = PG.GroupID

WHERE
    NOT EXISTS (

        SELECT * FROM People.PeopleGroups AS PG
        WHERE PG.PersonID = 1 AND G.GroupID = PG.GroupID
    );
GO
