CREATE OR ALTER PROCEDURE People.RetrieveGroups
    @GroupID INT,
    @GroupName NVARCHAR(50)
AS

SELECT
    G.GroupID,
    G.Name,
    G.Description
FROM People.Groups AS G
WHERE
    (@GroupID IS NOT NULL AND @GroupID = G.GroupID)
    OR (@GroupName IS NOT NULL AND G.Name LIKE ('%' + @GroupName + '%'))
    OR (@GroupID IS NULL AND @GroupName IS NULL);

GO
