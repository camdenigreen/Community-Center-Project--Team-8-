CREATE OR ALTER PROCEDURE [Events].RetrieveEventsByGroupID
    @GroupID INT
AS

SELECT
    E.EventID,
    E.Organizer,
    E.Name,
    E.Date,
    E.Description,
    E.GroupID,
    E.Charge
FROM [Events].[Events] AS E
    INNER JOIN People.Groups AS G ON E.GroupID = G.GroupID
WHERE G.GroupID = @GroupID
ORDER BY E.Date DESC

GO
