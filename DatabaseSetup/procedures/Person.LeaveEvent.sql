CREATE OR ALTER PROCEDURE Person.LeaveEvent
	@PersonId INT 
AS

UPDATE [Events].[EventAttendance] 
SET PersonID=NULL
WHERE PersonId=@PersonId
GO

