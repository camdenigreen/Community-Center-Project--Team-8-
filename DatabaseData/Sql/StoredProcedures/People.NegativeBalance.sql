CREATE OR ALTER PROCEDURE People.NegativeBalance

AS


SELECT
    Ag.PersonID,
    P.FirstName,
    P.LastName,
    P.PhoneNumber,
    SUM(Ag.Amount) AS Balance
FROM
    (
        SELECT
            Ct.PersonID,
            Ct.Amount
        FROM People.Charges AS Ct
        UNION ALL
        SELECT
            Pt.PersonID,
            Pt.Amount
        FROM People.Payments AS Pt
    ) AS Ag
INNER JOIN People.People AS P ON Ag.PersonID = P.PersonID
GROUP BY Ag.PersonID, P.FirstName, P.LastName, P.PhoneNumber
HAVING SUM(Ag.Amount) < 0
ORDER BY Balance ASC;

GO



