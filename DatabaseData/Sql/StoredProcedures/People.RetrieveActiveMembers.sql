CREATE PROCEDURE People.RetrieveActiveMembers
AS

SELECT
    G.GroupID,
    G.Name,
    SUM(PG.PersonID) AS TotalMembers,
    (
        SELECT SUM(PG.PersonID) AS ActiveMembers
        FROM People.PeopleGroups AS PG
        WHERE EXISTS (
            SELECT *
            FROM Events.EventAttendance AS EA
            INNER JOIN Events.Events AS E ON EA.EventID = E.EventID
            WHERE
                E.Date >= DATEADD(DAY, -30, GETDATE())
                AND EA.DidAttend = 1
                AND EA.PersonID = PG.PersonID
        )
    )
FROM People.Groups AS G
INNER JOIN People.PeopleGroups AS PG ON G.GroupID = PG.GroupID
GROUP BY G.GroupID, G.Name;

GO
