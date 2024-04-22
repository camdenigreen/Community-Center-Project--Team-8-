CREATE OR ALTER PROCEDURE Person.AddEvent
 @PersonId INT,
 @EventId INT
 AS
 INSERT INTO [Events].[Events]( PersonID,EventID)
 VALUES(@PersonId,@EventId);
 GO

