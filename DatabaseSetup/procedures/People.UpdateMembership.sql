CREATE OR ALTER PROCEDURE People.UpdateMembership
    @PersonID INT
AS


UPDATE People.People
    SET IsMember = 0
    WHERE PersonID = @PersonID;
DELETE FROM People.PeopleGroups
WHERE PersonID =@PersonID;

DELETE FROM [Events].[EventAttendance] 
WHERE PersonID=@PersonID;


GO