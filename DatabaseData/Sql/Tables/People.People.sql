IF OBJECT_ID(N'People.People') IS NULL
BEGIN
    CREATE TABLE [People].[People]
    (
        PersonID INT IDENTITY(1,1) PRIMARY KEY,
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        [Address] NVARCHAR(256) NOT NULL,
        PhoneNumber NVARCHAR(20) NOT NULL,
        IsMember BIT NOT NULL,

        CONSTRAINT UK_People_People_FirstName_LastName_PhoneNumber UNIQUE
        (
            FirstName,
            LastName,
            PhoneNumber
        )
    )
END