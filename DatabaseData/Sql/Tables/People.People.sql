IF OBJECT_ID(N'People.People') IS NULL
BEGIN
    CREATE TABLE [People].[People]
    (
        PersonID INT IDENTITY(1,1) PRIMARY KEY,
        FirstName NVARCHAR(50) UNIQUE NOT NULL,
        LastName NVARCHAR(50) UNIQUE NOT NULL,
        [Address] NVARCHAR(256) NOT NULL,
        PhoneNumber NVARCHAR(20) UNIQUE NOT NULL,
        IsMember BIT NOT NULL,
    )
END