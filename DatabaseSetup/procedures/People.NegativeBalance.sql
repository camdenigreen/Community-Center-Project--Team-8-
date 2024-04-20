CREATE OR ALTER PROCEDURE People.NegativeBalance
	
AS


SELECT P.PersonID,P.FirstName,P.LastName,P.PhoneNumber, SUM(C.Amount)-SUM(Pa.Amount) AS Balance
FROM [People].People P
LEFT JOIN People.Payments Pa ON Pa.PersonID=P.PersonID
JOIN People.Charges C on C.PersonID=P.PersonID
GROUP BY P.PersonID,P.FirstName,P.LastName,P.PhoneNumber
HAVING SUM(C.Amount)-SUM(Pa.Amount) >0
ORDER BY Balance ASC;

GO