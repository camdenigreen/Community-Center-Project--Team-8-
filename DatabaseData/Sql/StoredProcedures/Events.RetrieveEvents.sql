CREATE OR ALTER PROCEDURE [Events].RetrieveEvents
    @EventID INT,
    @EventName NVARCHAR(50)
AS

SELECT
    E.EventID,
    E.Organizer,
    E.Name,
    E.Date,
    E.Description,
    E.GroupID,
    G.Name AS GroupName,
    E.Charge
FROM [Events].[Events] AS E
LEFT JOIN People.Groups AS G ON E.GroupID = G.GroupID
WHERE (@EventID IS NOT NULL AND @EventID = E.EventID)
    OR (@EventName IS NOT NULL AND E.Name LIKE ('%' + @EventName + '%'))
    OR (@EventID IS NULL AND @EventName IS NULL);

GO
