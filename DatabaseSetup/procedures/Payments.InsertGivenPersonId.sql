CREATE OR ALTER PROCEDURE Payments.FetchPaymentsById
    @PersonID  INT,
    @Amount  MONEY,
    @Reason  NVARCHAR(MAX),
    @Date  DATETIME2(7),
    @PaymentId INT OUTPUT
AS

INSERT INTO People.Payments(PersonID, Amount, Reason, [Date])
VALUES(
    @PersonID,
    @Amount,
    @Reason,
    @Date
);
SET @PaymentId=SCOPE_IDENTITY();
GO