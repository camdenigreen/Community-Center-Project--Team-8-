CREATE OR ALTER PROCEDURE [Events].RetrievePeopleByEventID
    @EventID INT
AS

SELECT
    P.PersonID,
    P.FirstName,
    P.LastName,
    P.[Address],
    P.PhoneNumber
FROM [Events].EventAttendance AS EA
    INNER JOIN People.People AS P ON EA.PersonID = P.PersonID
WHERE EA.EventID = @EventID 
    AND P.IsMember = 1;

GO