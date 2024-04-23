CREATE OR ALTER PROCEDURE [Events].UpcomingEventsAggregated
AS

DECLARE @CurrentDate DATE
SET @CurrentDate = GETDATE()

SELECT
    E.EventID,
    E.Name,
    E.Date,
    SUM(EA.PersonID) AS Registrants
FROM [Events].[Events] AS E
INNER JOIN [Events].EventAttendance AS EA ON E.EventID = EA.EventID
WHERE E.Date >= @CurrentDate
GROUP BY E.EventID, E.Name, E.Date
ORDER BY Registrants DESC

GO
