CREATE OR ALTER PROCEDURE Person.RetrieveOtherEvents
 @PersonId INT

AS
SELECT E.Name,E.[Date]
FROM [Events].[Events] E
LEFT JOIN [Events].[EventAttendance] EA ON EA.EventID=E.EventID AND EA.PersonID=@PersonId
WHERE EA.PersonID IS NULL
ORDER BY E.Date ASC;
GO