CREATE OR ALTER PROCEDURE RetriveEventsByPersonID
    @PersonID INT
AS

SELECT
    E.EventID,
    E.Organizer,
    E.Name,
    E.Date,
    E.Description,
    E.Charge
FROM Events.Events AS E
INNER JOIN Events.EventAttendance AS EA ON EA.PersonID = @PersonID

GO
