CREATE OR ALTER PROCEDURE Events.RetrieveEventAttendanceByPersonID
    @PersonID INT
AS

SELECT
    P.FirstName,
    P.LastName,
    E.Name AS EventName,
    EA.DidAttend
FROM Events.EventAttendance AS EA
INNER JOIN People.People AS P ON EA.PersonID = P.PersonID
INNER JOIN Events.Events AS E ON EA.EventID = E.EventID
WHERE P.PersonID = @PersonID;

GO
