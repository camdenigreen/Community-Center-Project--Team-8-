CREATE PROCEDURE People.RetrieveGroupsByPerson
	@PersonID INT
AS

SELECT G.Name,G.Description
FROM People.Groups G
	JOIN People.PeopleGroups PG ON G.GroupID=PG.GroupID
WHERE PG.PersonID=@PersonID

GO
