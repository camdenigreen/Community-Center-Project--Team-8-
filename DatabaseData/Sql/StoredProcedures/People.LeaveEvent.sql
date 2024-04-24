CREATE OR ALTER PROCEDURE People.LeaveEvent
    @PersonId INT,
    @EventId INT
AS
DELETE FROM [Events].EventAttendance
WHERE PersonID=@PersonId AND EventID=@EventId;

GO