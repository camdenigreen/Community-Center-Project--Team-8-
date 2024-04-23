CREATE OR ALTER PROCEDURE Person.RetrieveOtherEvents
 @PersonId INT

AS
SELECT E.Name,E.[Date]
FROM [Events].[Events] E
JOIN [Events].[EventAttendance] EA ON EA.EventID=E.EventID
WHERE NOT EXISTS(

	SELECT * FROM 
	EA WHERE EA.PersonID=@PersonId)
ORDER BY E.Date ASC;
GO