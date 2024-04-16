IF OBJECT_ID(N'People.Payments') IS NULL
BEGIN
    CREATE TABLE [People].Payments
    (
        PaymentID INT PRIMARY KEY,
        PersonID INT FOREIGN KEY REFERENCES People.People(PersonID) NOT NULL,
        Amount MONEY NOT NULL,
        Reason NVARCHAR(MAX),
        [Date] DATETIME2(7) NOT NULL,
    )
END