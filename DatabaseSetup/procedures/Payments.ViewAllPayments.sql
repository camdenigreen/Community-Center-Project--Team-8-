CREATE OR ALTER PROCEDURE Payments.ViewAllPayments
AS

SELECT P.PaymentID, P.PersonID, E.Firstname, E.LastName, P.Amount, P.Reason, P.[Date]
FROM People.Payments AS P
INNER JOIN People.People AS E ON P.PersonID = E.PersonID;
GO