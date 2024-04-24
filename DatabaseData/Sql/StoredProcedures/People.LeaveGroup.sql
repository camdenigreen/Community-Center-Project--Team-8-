CREATE OR ALTER PROCEDURE People.LeaveGroup
    @PersonId INT,
    @GroupId INT
AS
DELETE FROM People.PeopleGroups
WHERE PersonID=@PersonId AND GroupID=@GroupId;

GO
