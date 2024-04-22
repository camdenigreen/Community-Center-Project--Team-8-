CREATE OR ALTER PROCEDURE People.LeaveEvent
	@PersonId INT 
AS

UPDATE [Events].[EventAttendance] 
SET PersonID=NULL
WHERE PersonId=@PersonId
GO

