CREATE OR ALTER PROCEDURE People.AddPersonToGroup
    @PersonID INT,
    @GroupName NVARCHAR(26)
AS

INSERT INTO People.PeopleGroups (GroupID,PersonID)
VALUES (
    (SELECT PersonID FROM People.People WHERE PersonID=@PersonID),
    (SELECT GroupID FROM People.Groups WHERE [Name]=@GroupName) 
    );

GO
