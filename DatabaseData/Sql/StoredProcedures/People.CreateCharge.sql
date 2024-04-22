CREATE OR ALTER PROCEDURE People.CreateCharge
    @PersonID INT,
    @Amount MONEY,
    @Reason NVARCHAR(MAX),
    @Date DATETIME2(7),
    @EventID INT,
    @ChargeID INT OUTPUT
AS

INSERT People.Charges (PersonID, EventID, Amount, Reason, Date)
VALUES (@PersonID, @EventID, @Amount, @Reason, @Date)

SET @ChargeID = SCOPE_IDENTITY();

GO
