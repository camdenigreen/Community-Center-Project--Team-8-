CREATE OR ALTER PROCEDURE RetrieveGroups
	@GroupID INT,
	@GroupName NVARCHAR(50)
AS 

SELECT G.Name,G.Description
FROM People.Groups G
WHERE (@GroupID IS NOT NULL AND @GroupID = G.GroupID)
	OR (@GroupName IS NOT NULL AND @GroupName = G.GroupName)
	OR (@GroupID IS NULL AND @GroupName IS NULL);

GO