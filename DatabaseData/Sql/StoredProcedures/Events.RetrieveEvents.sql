CREATE OR ALTER PROCEDURE [Events].RetrieveEvents
    @EventID INT,
    @EventName NVARCHAR(50)
AS

SELECT E.EventID, E.Organizer, E.[Name], E.[Date], E.[Description], G.[Name] AS GroupName, E.Charge
FROM [Events].[Events] E
    INNER JOIN People.Groups G ON E.GroupID = G.GroupID
WHERE (
        (@EventID IS NOT NULL AND @EventID = E.EventID)
        OR  
        (@EventID IS NULL)
    ) AND
    (
        (@EventName IS NOT NULL AND @EventName = @EventID)
        OR
        (@EventName IS NULL)
    )

GO
