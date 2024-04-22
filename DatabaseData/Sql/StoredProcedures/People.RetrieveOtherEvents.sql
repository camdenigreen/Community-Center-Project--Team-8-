CREATE OR ALTER PROCEDURE People.RetrieveOtherEvents
    @PersonId INT

AS
SELECT
    E.Name,
    E.Date
FROM Events.Events AS E
INNER JOIN Events.EventAttendance AS EA ON E.EventID = EA.EventID
WHERE
    NOT EXISTS (

        SELECT * FROM
            EA
        WHERE EA.PersonID = @PersonId
    )
ORDER BY E.Date ASC;
GO
