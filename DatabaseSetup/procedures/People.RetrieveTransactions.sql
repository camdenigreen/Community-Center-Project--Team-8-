﻿CREATE OR ALTER PROCEDURE People.RetrieveTransactions
    @PersonID INT
AS

SELECT Type,Amount,[Date],Reason
FROM(
    SELECT N'Payment' AS Type, P.Amount AS Amount, P.[Date],P.Reason 
    FROM People.Payments P
    WHERE P.PersonID=@PersonID
    UNION ALL
    SELECT N'Charge' AS Type, C.Amount,C.[Date],C.Reason
    FROM  People.Charges C
    WHERE C.PersonID=@PersonID
    )As H
ORDER BY H.[Date]

GO