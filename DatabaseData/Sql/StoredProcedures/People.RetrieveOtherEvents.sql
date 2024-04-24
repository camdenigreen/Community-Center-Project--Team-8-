CREATE OR ALTER PROCEDURE People.RetrieveOtherEvents
    @PersonId INT


AS
SELECT
    E.Name,
    E.Date,
    E.GroupID,
    E.Description,
    E.Organizer,
    E.Date,
    E.Charge,
    E.EventID
FROM Events.Events AS E
WHERE
    NOT EXISTS (

        SELECT *
        FROM  [Events].EventAttendance AS EA 
        WHERE EA.PersonID =@PersonId AND E.EventID=EA.EventID
    )
ORDER BY E.Date ASC;
GO
