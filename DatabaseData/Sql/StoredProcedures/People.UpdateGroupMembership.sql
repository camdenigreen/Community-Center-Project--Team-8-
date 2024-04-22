CREATE OR ALTER PROCEDURE People.UpdateGroupMembership
    @PersonID INT,
    @GroupName NVARCHAR(26),
    @PreviousGroup NVARCHAR(26)
AS 

UPDATE People.PeopleGroups 
SET GroupID=( SELECT GroupID FROM People.Groups WHERE [Name]=@GroupName)
WHERE PersonID=@PersonID
    AND GroupID=( SELECT GroupID FROM People.Groups WHERE [Name]=@PreviousGroup);

GO
