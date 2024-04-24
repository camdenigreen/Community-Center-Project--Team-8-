CREATE OR ALTER PROCEDURE People.RetrieveBalance
    @PersonID INT
AS

SELECT SUM(ag.Amount) AS Balance
FROM
    (
    SELECT  ct.Amount,ct.PersonID FROM People.Charges ct
	WHERE ct.PersonID=1
    UNION ALL
    SELECT pt.Amount,pt.PersonID FROM People.Payments pt
	WHERE pt.PersonID=1
    ) ag 
   
GROUP BY ag.PersonID;



GO
