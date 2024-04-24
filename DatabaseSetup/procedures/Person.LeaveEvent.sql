CREATE OR ALTER PROCEDURE Person.LeaveEvent
	@PersonId INT, 
	@EventId INT
AS

DELETE FROM [Events].EventAttendance
WHERE EA.PersonID=@PersonId AND EA.EventID=@EventId;

GO

