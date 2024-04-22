CREATE OR ALTER PROCEDURE AddPerson
	AS


DECLARE @CurrentDate DATE
SET @CurrentDate =GETDATE()


SELECT E.EventID, E.Name,E.Date, SUM(EA.PersonID) AS Registrants
FROM [Events].[Events] E
JOIN [Events].EventAttendance EA ON E.EventID=EA.EventID
WHERE E.Date >=@CurrentDate
GROUP BY E.EventID,E.Name,E.Date
ORDER BY Registrants DESC


SET @PersonID =SCOPE_IDENTITY();
GO