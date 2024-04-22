CREATE OR ALTER PROCEDURE People.RetrieveOtherGroups
 @PersonId INT

AS
SELECT G.Name,G.[Description]
FROM People.Groups G
JOIN People.PeopleGroups PG ON G.GroupID=PG.GroupID

WHERE NOT EXISTS(

	SELECT * FROM PG
	WHERE PG.PersonID=@PersonId)
ORDER BY E.Date ASC;
GO