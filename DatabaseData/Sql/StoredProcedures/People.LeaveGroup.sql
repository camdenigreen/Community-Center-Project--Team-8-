CREATE OR ALTER PROCEDURE People.LeaveGroup	
	@PersonId INT 
AS

UPDATE People.PeopleGroups 
SET PersonID=NULL
WHERE PersonId=@PersonId
GO


