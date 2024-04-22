CREATE OR ALTER PROCEDURE Person.LeaveGroup	
	@PersonId INT 
AS

UPDATE People.PeopleGroups 
SET PersonID=NULL
WHERE PersonId=@PersonId
GO


