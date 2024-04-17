CREATE OR ALTER PROCEDURE CreateGroup
	@Name  NVARCHAR(26),
    @Description NVARCHAR(226)
	
AS
INSERT People.Groups ([Name],Description)
VALUES(@Name,@Description) 
GO;