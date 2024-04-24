CREATE OR ALTER PROCEDURE People.NegativeBalance
	
AS


SELECT ag.PersonID, P.FirstName,P.LastName,P.PhoneNumber, SUM(ag.Amount) AS Balance
FROM
    (
    SELECT ct.PersonID, ct.Amount FROM People.Charges ct
    UNION ALL
    SELECT pt.PersonID, pt.Amount FROM People.Payments pt
    ) ag 
    INNER JOIN People.People P ON ag.PersonID = P.PersonID
GROUP BY ag.PersonID,P.FirstName,P.LastName,P.PhoneNumber
HAVING SUM(ag.Amount) < 0
ORDER BY Balance ASC;

GO


