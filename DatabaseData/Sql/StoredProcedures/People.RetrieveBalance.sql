CREATE OR ALTER PROCEDURE People.RetrieveBalance
    @PersonID INT
AS

SELECT SUM(ag.Amount) AS Balance
FROM
    (
    SELECT  ct.Amount,ct.PersonID FROM People.Charges ct
	WHERE ct.PersonID=@PersonID
    UNION ALL
    SELECT pt.Amount,pt.PersonID FROM People.Payments pt
	WHERE pt.PersonID=@PersonID
    ) ag 
   
GROUP BY ag.PersonID;



GO
