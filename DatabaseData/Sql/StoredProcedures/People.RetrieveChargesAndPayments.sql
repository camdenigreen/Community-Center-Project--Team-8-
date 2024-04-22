CREATE OR ALTER PROCEDURE People.RetrieveChargesAndPayments
    @PersonID INT
AS

SELECT
    H.Type,
    H.Amount,
    H.Date,
    H.Reason
FROM (
    SELECT
        N'Paymnt' AS Type,
        P.Amount,
        P.Date,
        P.Reason
    FROM People.Payments AS P
    WHERE P.PersonID = @PersonID

    UNION ALL

    SELECT
        N'Charge' AS Type,
        C.Amount,
        C.Date,
        C.Reason
    FROM People.Charges AS C
    WHERE C.PersonID = @PersonID
) AS H
ORDER BY H.Date

GO
