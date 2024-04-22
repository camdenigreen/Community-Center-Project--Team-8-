CREATE OR ALTER PROCEDURE [Events].UpdateEventAttendance
    @PersonID INT,
    @EventID INT
AS

UPDATE [Events].EventAttendance
SET DidAttend = 1
WHERE PersonID = @PersonID
    AND EventID = @EventID

GO
