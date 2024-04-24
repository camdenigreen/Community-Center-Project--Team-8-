CREATE PROCEDURE People.RetrieveActiveMembers
AS

WITH EventAttendences(EventID, PersonID, GroupID) AS (
    SELECT EA.EventID, EA.PersonID, E.GroupID
    FROM [Events].EventAttendance EA
        INNER JOIN [Events].[Events] E ON EA.EventID = E.EventID
    WHERE EA.DidAttend=1
        AND (CAST(E.Date AS smalldatetime)) >= DATEADD(day,-30,GETDATE())
)
SELECT G.GroupID, G.Name, G.Description, COUNT(DISTINCT PG.PersonID) AS TotalMembers, COUNT(DISTINCT EAS.PersonID) AS ActiveMembers, CAST(COUNT(DISTINCT EAS.PersonID) AS float)/CAST(COUNT(DISTINCT PG.PersonID) AS float) AS PercentageOfActiveMembers
FROM People.Groups G
    INNER JOIN People.PeopleGroups PG ON G.GroupID = PG.GroupID
    LEFT JOIN EventAttendences EAS ON G.GroupID = EAS.GroupID
GROUP BY G.GroupID, G.Name, G.Description
ORDER BY ActiveMembers DESC;
GO
