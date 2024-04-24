CREATE PROCEDURE People.RetrieveActiveMembers
AS

WITH EventAttendences (EventID, PersonID, GroupID) AS (
    SELECT
        EA.EventID,
        EA.PersonID,
        E.GroupID
    FROM Events.EventAttendance AS EA
    INNER JOIN Events.Events AS E ON EA.EventID = E.EventID
    WHERE
        EA.DidAttend = 1
        AND (CAST(E.Date AS smalldatetime)) >= DATEADD(DAY, -30, GETDATE())
)

SELECT
    G.GroupID,
    G.Name,
    G.Description,
    COUNT(DISTINCT PG.PersonID) AS TotalMembers,
    COUNT(DISTINCT EAS.PersonID) AS ActiveMembers,
    CAST(COUNT(DISTINCT EAS.PersonID) AS float)
    / CAST(COUNT(DISTINCT PG.PersonID) AS float) AS PercentageOfActiveMembers
FROM People.Groups AS G
INNER JOIN People.PeopleGroups AS PG ON G.GroupID = PG.GroupID
LEFT JOIN EventAttendences AS EAS ON G.GroupID = EAS.GroupID
GROUP BY G.GroupID, G.Name, G.Description
ORDER BY ActiveMembers DESC;
GO
