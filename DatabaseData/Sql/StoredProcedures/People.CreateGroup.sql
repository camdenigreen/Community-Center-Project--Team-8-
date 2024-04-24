CREATE OR ALTER PROCEDURE People.CreateGroup
    @Name NVARCHAR(50),
    @Description NVARCHAR(MAX),
    @GroupID INT OUTPUT
AS

INSERT People.Groups (Name, Description)
VALUES (@Name, @Description)

SET @GroupID = SCOPE_IDENTITY()

GO
