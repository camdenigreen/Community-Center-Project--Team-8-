CREATE OR ALTER PROCEDURE Charges.RetrieveChargesByPersonId
    @PersonID INT
AS

SELECT C.ChargeID, P.FirstName, P.LastName, E.[Name] AS EventName, C.Amount, C.[Date]
FROM People.Charges C
    INNER JOIN People.People P ON C.PersonID = P.PersonID
    LEFT JOIN Events.Events E ON C.EventID = E.EventID
    WHERE C.PersonID = @PersonID

GO