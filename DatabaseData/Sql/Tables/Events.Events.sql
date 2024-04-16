IF OBJECT_ID(N'Events.Events') IS NULL
BEGIN
    CREATE TABLE [Events].[Events]
    (
        EventID INT IDENTITY(1,1) PRIMARY KEY,
        Organizer NVARCHAR(50) NOT NULL,
        [Name] NVARCHAR(50) UNIQUE NOT NULL,
        [Date] DATETIME2(7) NOT NULL,
        [Description] NVARCHAR(MAX),
        GroupID INT NULL FOREIGN KEY REFERENCES  People.Groups(GroupID),
        Charge MONEY NOT NULL,
    )
END