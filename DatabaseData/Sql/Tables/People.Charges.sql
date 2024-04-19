IF OBJECT_ID(N'People.Charges') IS NULL
BEGIN
    CREATE TABLE [People].Charges
    (
        ChargeID INT IDENTITY(1, 1) PRIMARY KEY,
        PersonID INT FOREIGN KEY REFERENCES People.People(PersonID) NOT NULL,
        EventID INT FOREIGN KEY REFERENCES [Events].[Events](EventID),
        Amount MONEY NOT NULL,
        Reason NVARCHAR(MAX),
        [Date] DATETIME2(7) NOT NULL,
    )
END