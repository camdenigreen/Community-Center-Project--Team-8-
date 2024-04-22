CREATE OR ALTER PROCEDURE People.RetrieveChargesByPersonId
    @PersonID INT
AS

SELECT
    C.ChargeID,
    P.FirstName,
    P.LastName,
    E.Name AS EventName,
    C.Amount,
    C.Date
FROM People.Charges AS C
INNER JOIN People.People AS P ON C.PersonID = P.PersonID
LEFT JOIN Events.Events AS E ON C.EventID = E.EventID
WHERE C.PersonID = @PersonID

GO
