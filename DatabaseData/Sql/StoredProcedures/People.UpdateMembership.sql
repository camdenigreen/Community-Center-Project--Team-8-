CREATE OR ALTER PROCEDURE People.UpdateMembership
    @PersonID INT
AS

UPDATE People.People
SET IsMember = 0
WHERE PersonID = @PersonID;

GO
