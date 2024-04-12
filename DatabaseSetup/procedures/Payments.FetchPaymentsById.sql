CREATE OR ALTER PROCEDURE Payments.FetchPaymentsById
    @PersonID INT
AS

SELECT P.PaymentID, P.PersonID, E.FirstName, E.LastName, P.Amount, P.Reason, P.[Date]
FROM People.Payments AS P
INNER JOIN People.People AS E ON P.PersonID = E.PersonID
WHERE P.PersonID = @PersonID;
GO