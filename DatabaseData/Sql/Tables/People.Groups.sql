IF OBJECT_ID(N'People.Groups') IS NULL
BEGIN
    CREATE TABLE [People].Groups
    (
        GroupID INT IDENTITY(1,1) PRIMARY KEY,
        [Name] NVARCHAR(50) UNIQUE NOT NULL,
        [Description] NVARCHAR(MAX),
    )
END