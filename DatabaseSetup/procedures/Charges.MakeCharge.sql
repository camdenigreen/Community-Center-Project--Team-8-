CREATE OR ALTER PROCEDURE Charges.MakeCharge
    @PersonID  INT,
    @Amount  MONEY,
    @Reason  NVARCHAR(MAX),
    @Date  DATETIME2(7),
    @EventID INT,
    @ChargesID INT OUTPUT
AS

INSERT People.Charges(PersonID, EventID, Amount, Reason, [Date])
Values(@PersonID, @EventID, @Amount, @Reason, @Date)  

SET @ChargesID=SCOPE_IDENTITY();
GO