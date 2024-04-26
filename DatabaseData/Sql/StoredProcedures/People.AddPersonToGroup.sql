CREATE OR ALTER PROCEDURE People.AddPersonToGroup
    @PersonID INT,
    @GroupID INT
AS

INSERT INTO People.PeopleGroups (GroupID, PersonID)
VALUES (@GroupID,@PersonID);

GO
