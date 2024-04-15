CREATE OR ALTER PROCEDURE RetrievPersonGroups
 @PersonId INT

AS
SELECT G.Name,G.[Description]
FROM People.Groups G
JOIN People.PeopleGroups PG ON G.GroupID=PG.GroupID
AND PG.PersonID=@PersonId

GO