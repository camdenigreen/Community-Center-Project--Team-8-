CREATE OR ALTER PROCEDURE [Events].RetrievPersonEvents
    @PersonId INT
AS

SELECT
    E.EventID,
    E.Name,
    E.GroupID,
    E.Description,
    E.Organizer,
    E.Date,
    E.Charge
FROM [Events].[Events] AS E
INNER JOIN [Events].EventAttendance AS EA ON E.EventID = EA.EventID
WHERE EA.PersonID = @PersonId
ORDER BY E.Date ASC;

GO
