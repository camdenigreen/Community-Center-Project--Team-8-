CREATE OR ALTER PROCEDURE RetrieveEvents
@PersonID INT
AS

SELECT E.EventID, E.Organizer, E.[Name], E.[Date], E.[Description], G.[Name] AS GroupName, E.Charge
FROM [Events].[Events] E
INNER JOIN [Events].Eventtendance EA ON EA.PersonID=@PersonID;
    
    
GO