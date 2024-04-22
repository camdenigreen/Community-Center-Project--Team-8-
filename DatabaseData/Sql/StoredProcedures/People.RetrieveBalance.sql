CREATE OR ALTER PROCEDURE People.RetrieveBalance
    @PersonID  INT
AS

SELECT SUM(C.Amount)-SUM(Pa.Amount) AS Balance
FROM [People].People P
    LEFT JOIN People.Payments Pa ON Pa.PersonID=P.PersonID
    JOIN People.Charges C on C.PersonID=P.PersonID
WHERE P.PersonID=@PersonID
GROUP BY P.PersonID,P.FirstName,P.LastName,P.PhoneNumber;

GO
