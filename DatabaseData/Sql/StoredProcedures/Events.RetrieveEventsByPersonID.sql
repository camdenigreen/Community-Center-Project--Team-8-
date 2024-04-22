CREATE OR ALTER PROCEDURE [Events].RetriveEventsByPersonId
    @PersonID INT
AS

SELECT E.EventID, E.Organizer, E.[Name], E.[Date], E.[Description], E.Charge
FROM [Events].[Events] E
    INNER JOIN [Events].EventAttendance EA ON EA.PersonID=@PersonID

GO
