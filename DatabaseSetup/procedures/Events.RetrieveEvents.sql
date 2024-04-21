CREATE OR ALTER PROCEDURE Events.RetrieveEvents
AS

SELECT E.EventID, E.Organizer, E.[Name], E.[Date], E.[Description], G.[Name] AS GroupName, E.Charge
FROM [Events].[Events] E
    INNER JOIN People.Groups G ON E.GroupID = G.GroupID;

GO
