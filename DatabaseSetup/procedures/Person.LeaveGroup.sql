CREATE OR ALTER PROCEDURE Person.LeaveGroup	
	@PersonId INT, 
    @GroupId INT
AS

DELETE FROM People.PeopleGroups
WHERE PersonID=@PersonId AND GroupID=@GroupId;

GO


