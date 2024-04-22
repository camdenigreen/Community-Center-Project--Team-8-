CREATE OR ALTER PROCEDURE People.RetrieveBalance
    @PersonID INT
AS

SELECT SUM(C.Amount) - SUM(Pa.Amount) AS Balance
FROM People.People AS P
LEFT JOIN People.Payments AS Pa ON P.PersonID = Pa.PersonID
INNER JOIN People.Charges AS C ON P.PersonID = C.PersonID
WHERE P.PersonID = @PersonID
GROUP BY P.PersonID, P.FirstName, P.LastName, P.PhoneNumber;

GO
