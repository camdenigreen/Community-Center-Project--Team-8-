CREATE PROCEDURE People.RetrieveActiveMembers
AS

SELECT G.GroupID,G.Name, SUM( PG.PersonID) AS TotalMembers,(
SELECT SUM(PG.PersonID) AS ActiveMembers
	FROM People.PeopleGroups PG
		WHERE EXISTS(
			SELECT *
			FROM [Events].EventAttendance EA
				JOIN [Events].[Events] E ON E.EventID=EA.EventID
			WHERE E.Date >= DATEADD(day,-30,GETDATE())
				AND EA.DidAttend=1
				AND EA.PersonID=PG.PersonID
				)
		)
FROM People.Groups G
	JOIN People.PeopleGroups PG ON PG.GroupID=G.GroupID
GROUP BY G.GroupID,G.Name;

GO
