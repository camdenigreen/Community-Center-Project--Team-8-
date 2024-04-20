CREATE OR ALTER PROCEDURE [Events].RetrievPersonEvents
 @PersonId INT

AS
SELECT E.Name,E.[Date]
FROM [Events].[Events] E
	JOIN [Events].[EventAttendance] EA ON EA.EventID=E.EventID
WHERE EA.PersonID=@PersonId
ORDER BY E.Date ASC;
GO