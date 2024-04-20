CREATE OR ALTER PROCEDURE [Events].RetrieveEventsByPersonID
   @PersonID INT
AS

SELECT E.EventID, E.GroupID, E.[Description], E.Organizer, E.[Date], E.Charge, E.[Name]
FROM [Events].EventAttendance EA
    INNER JOIN People.People P ON EA.PersonID = P.PersonID
    INNER JOIN [Events].[Events] E ON EA.EventID = E.EventID
    WHERE E.PersonID = @PersonID;
GO
