CREATE OR ALTER PROCEDURE Person.AddGroup
 @PersonId INT,
 @GroupId INT
 AS
 INSERT INTO People.PeopleGroups( PersonID,GroupID)
 VALUES(@PersonId,@GroupId);
 GO

