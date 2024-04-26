CREATE OR ALTER PROCEDURE People.LeaveGroup
    @PersonID INT,
    @GroupID INT
AS
DELETE FROM People.PeopleGroups
WHERE PersonID=@PersonId AND GroupID=@GroupId;

GO
