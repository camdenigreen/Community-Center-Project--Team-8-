CREATE OR ALTER PROCEDURE RetriveEventsByPersonId
    @PersonID INT
AS

SELECT E.EventID, E.Organizer, E.[Name], E.[Date], E.[Description], E.Charge,G.GroupID AS GroupID,E.Charge,EA.DidAttend
FROM [Events].[Events] E
    INNER JOIN [Events].EventAttendance EA ON EA.PersonID=@PersonID
    INNER JOIN People.Groups G ON G.GroupID=E.GroupID;
GO