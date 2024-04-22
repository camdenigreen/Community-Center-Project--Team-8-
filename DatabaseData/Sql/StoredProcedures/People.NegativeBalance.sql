CREATE OR ALTER PROCEDURE People.NegativeBalance
AS

SELECT
    P.PersonID,
    P.FirstName,
    P.LastName,
    P.PhoneNumber,
    SUM(C.Amount) - SUM(Pa.Amount) AS Balance
FROM People.People AS P
LEFT JOIN People.Payments AS Pa ON P.PersonID = Pa.PersonID
INNER JOIN People.Charges AS C ON P.PersonID = C.PersonID
GROUP BY P.PersonID, P.FirstName, P.LastName, P.PhoneNumber
HAVING SUM(C.Amount) - SUM(Pa.Amount) > 0
ORDER BY Balance ASC;

GO
