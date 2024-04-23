CREATE OR ALTER PROCEDURE People.RetrieveBalance
    @PersonID  INT
   
AS
SELECT  ISNULL(0,SUM(Pa.Amount))-SUM(C.Amount) AS Balance
FROM [People].People P
LEFT JOIN People.Payments Pa ON Pa.PersonID=P.PersonID
LEFT JOIN People.Charges C on C.PersonID=P.PersonID
WHERE P.PersonID=1
GROUP BY P.PersonID,P.FirstName,P.LastName,P.PhoneNumber;

GO