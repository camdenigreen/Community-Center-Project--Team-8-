CREATE OR ALTER PROCEDURE CreateEvents
	@Organizer NVARCHAR(100),
	@Name NVARCHAR(100),
	@Date DATETIME2(7),
	@Description NVARCHAR(MAX),
	@GroupID INT,
	@Charge MONEY,
	@EventID INT OUTPUT 

AS
INSERT [Events].[Events](Organizer, [Name], [Date], [Description], GroupID, Charge)
VALUES(@Organizer, @Name, @Date, @Description, @GroupID, @Charge)

SET @EventID = SCOPE_IDENTITY();


GO
