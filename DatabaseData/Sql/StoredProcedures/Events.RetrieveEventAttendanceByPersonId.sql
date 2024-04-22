CREATE OR ALTER PROCEDURE [Events].RetrieveEventAttendanceByPersonID
   @PersonID INT
AS

SELECT P.FirstName, P.LastName, E.[Name] AS EventName, EA.DidAttend
FROM [Events].EventAttendance EA
    INNER JOIN People.People P ON EA.PersonID = P.PersonID
    INNER JOIN [Events].[Events] E ON EA.EventID = E.EventID
WHERE E.PersonID = @PersonID;

GO
